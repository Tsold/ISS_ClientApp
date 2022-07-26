using ISS_App.FaceRecog;
using ISS_App.LocalServices;
using ISS_App.Model;
using ISS_App.Model.Json;
using ISS_App.POST;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISS_App
{
    public partial class AlbumApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDDl();
                }
                catch (Exception ex)
                {

                    LblInfo.Text = ex.Message;
                }
            }
        }

        private async void LoadDDl()
        {
            DdlALbum.DataSource = await LocalApiHandler.GetAlbumInfoAsync();
            DdlALbum.DataTextField = "Album";
            DdlALbum.DataValueField = "Albumkey";
            DdlALbum.DataBind();
        }

       
        protected async void BtnAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                LblInfo.Text = await LocalApiHandler.SendAlbumInfoAsync(await RecogHandler.CreateAlbumAsync(TbAlbum.Text));
                LoadDDl();
            }
            catch (Exception)
            {

                LblInfo.Text = "Album name taken";
            }
          
        }

        protected async void BtnInsert_Click(object sender, EventArgs e)
        {
            People peps = LocalApiHandler.GetPeople();
            LblInfo.Text = await RecogHandler.InsertIntoAlbumAsync(peps, new AlbumInfo(DdlALbum.SelectedItem.Text,DdlALbum.SelectedValue));
        }

        protected async void BtnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                LblInfo.Text = await RecogHandler.RebuildAlbumAsync(new AlbumInfo(DdlALbum.SelectedItem.Text, DdlALbum.SelectedValue));
            }
            catch (Exception)
            {

                LblInfo.Text = "Insert More Samples";
            }
           
        }

        protected async void BtnView_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            AlbumPeople albs = await RecogHandler.ViewALbumAsync(new AlbumInfo(DdlALbum.SelectedItem.Text, DdlALbum.SelectedValue));
            builder.Append("<b>Album name: </b>" + albs.Name);
            builder.Append("<br />");
            builder.Append("<br />");
            foreach (string s in albs.Entries) {
                builder.Append("<b>Name: </b> " + s);
                builder.Append("<br />");
            }
            builder.Append("<br />");
            builder.Append("<br />");
            builder.Append("<b>Album size: </b>" + albs.Size);

            LblInfo.Text = builder.ToString();

        }

        protected async void BtnRecog_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                RecognizePerson recP = await RecogHandler.RecognizeUrlPerson(TbUrl.Text, new AlbumInfo(DdlALbum.SelectedItem.Text, DdlALbum.SelectedValue));
                builder.Append("<b>Connection: </b>" + recP.Status);
                builder.Append("<br />");
                builder.Append("<br />");
                if (recP.photo.Count == 0)
                {
                    builder.Append("Invalid Url");
                }
                foreach (Photo p in recP.photo)
                {
                    foreach (Tag t in p.tag)
                    {

                        foreach (Uid uid in t.Uids)
                        {

                            builder.Append("<b>" + uid.Prediction + "</ b >" + ": " + uid.Confidence * 100 + "%");
                            builder.Append("<br />");
                        }
                    }
                }
            }
            catch (Exception)
            {

                builder.Append("Invalid Url");
            }

            LblInfo.Text = builder.ToString();
        }

        protected async void BtnInsertIntoALbum_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person(TbName.Text, TbSurname.Text, UrlAddUser.Text);
                List<Person> pers = new List<Person>();
                pers.Add(person);
                People peps = new People(pers);
                LblInfo.Text = await RecogHandler.InsertIntoAlbumAsync(peps, new AlbumInfo(DdlALbum.SelectedItem.Text, DdlALbum.SelectedValue));
            }
            catch (Exception)
            {
                LblInfo.Text ="Invalid Url";
            }
          

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string output = LocalApiHandler.DeleteAlbum(DdlALbum.SelectedItem.Text);
            LblInfo.Text = output;
            LoadDDl();
        }
    }
}