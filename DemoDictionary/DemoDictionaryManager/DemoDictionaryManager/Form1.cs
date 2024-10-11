using DemoDictionaryManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDictionaryManager
{
    public partial class Form1 : Form
    {
        // create an object of my manager or repository class 
        MovieManager movieManager = new MovieManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // add movie to the dictionary 
            //int key = Convert.ToInt32(textBoxId.Text);
            Movie movie = new Movie();

            movie.Id = Convert.ToInt32(textBoxId.Text); // as a key 
            movie.Title = textBoxTitle.Text;
            movie.Director = textBoxDirector.Text;
            if (comboBoxGenre.Text == "Comedy")
            {
                movie.Genre = Genre.Comedy;
            }
            else if (comboBoxGenre.Text == Genre.Action.ToString())
            {
                movie.Genre = Genre.Action;
            }
            else
            {
                movie.Genre = Genre.Drama;
            }
            movie.YearOfProduction = Convert.ToInt32(textBoxYear.Text);

            movieManager.addMovie(movie.Id, movie);

            loadData();
            //display 
        }
        private void loadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Director");
            dt.Columns.Add("Genre");
            dt.Columns.Add("Year Of Production");

            foreach (var movie in movieManager.Movies)
            {
                dt.Rows.Add(movie.Value.Title, movie.Value.Director, movie.Value.Genre, movie.Value.YearOfProduction);
            }

            dataGridView1.DataSource = dt;
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(textBoxId.Text);
            Movie updateMovie = new Movie();

            if (movieManager.Movies.ContainsKey(key))
            {
                updateMovie.Id = int.Parse(textBoxId.Text);
                updateMovie.Director = textBoxDirector.Text;
                updateMovie.Title = textBoxTitle.Text;
                if (comboBoxGenre.Text == "Comedy")
                {
                    updateMovie.Genre = Genre.Comedy;
                }
                else if (comboBoxGenre.Text == Genre.Action.ToString())
                {
                    updateMovie.Genre = Genre.Action;
                }
                else
                {
                    updateMovie.Genre = Genre.Drama;
                }
                updateMovie.YearOfProduction = Convert.ToInt32(textBoxYear.Text);

                movieManager.editMovie(key, updateMovie);
            }
            else
            {
                MessageBox.Show("Error!");
            }
            loadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int keyToRemove = Convert.ToInt32(textBoxId.Text);
            if (movieManager.Movies.ContainsKey(keyToRemove))
            {
                movieManager.removeMovie(keyToRemove);
                loadData();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            foreach (var movie in movieManager.Movies)
            {
                if (movie.Value.Title == textBoxSearchTitle.Text && movie.Value.Director == textBoxSearchDirector.Text)
                {
                    MessageBox.Show("Title: " + movie.Value.Title + "\nGenre: " + movie.Value.Genre + "\nYear: " + movie.Value.YearOfProduction);
                }
            }
        }
    }
}
