using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviews.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<BookReviews.Models.Book> GridViewBooks_GetData()
        {
            IQueryable<Book> books = null;
            var dbContext = new BooksReviewContext();
            books = dbContext.Books.Include("Category").AsQueryable<Book>();
            return books;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = true;
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            var dbContext = new BooksReviewContext();
            var book = dbContext.Books.Find(id);
            var categories = dbContext.Categories.ToList();
            this.AddBook.Visible = false;
            this.PanelTitle.Text = "Edit Book";
            this.TitleTextBox.Text = book.Title;
            this.AuthorTextBox.Text = book.Author;
            this.ISBNTextBox.Text = book.ISBN;
            this.UrlTextBox.Text = book.SiteURL;
            this.DescrTextBox.Text = book.Description;
            this.CategoryDropDownList.DataSource = categories;
            this.CategoryDropDownList.DataBind();
            int indexSel = 0;
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Id==book.CategoryId)
                {
                    indexSel = i;
                    break;
                }
            }
            this.CategoryDropDownList.SelectedIndex =indexSel;
            this.EditOrCreateBook.Text = "Edit";
            this.EditOrCreateBook.CommandName = "edit";
            this.EditOrCreateBook.CommandArgument = id.ToString();

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            this.AddBook.Visible = false;
           
            this.PanelTitle.Text = "Confirm Delete Category";
            this.BookPanel.Visible = true;
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            using (var dbContext = new BooksReviewContext())
            {
                var book = dbContext.Books.Find(id);
                this.TitleTextBox.Text = book.Title;
                this.TitleTextBox.ReadOnly = true;
                this.AuthorLabel.Visible = false;
                this.AuthorTextBox.Visible = false;
                this.ISBN.Visible = false;
                this.ISBNTextBox.Visible = false;
                this.UrlLabel.Visible = false;
                this.UrlTextBox.Visible = false;
                this.DescrLabel.Visible = false;
                this.DescrTextBox.Visible = false;
                this.CategoryLabel.Visible = false;
                this.CategoryDropDownList.Visible = false;
                this.EditOrCreateBook.Text = "Delete";
                this.EditOrCreateBook.CommandArgument = id.ToString();
                this.EditOrCreateBook.CommandName = "delete";
            }

        }

        protected void AddBook_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = true;
            var dbContext = new BooksReviewContext();
            var categories = dbContext.Categories.ToList();
            this.AddBook.Visible = false;
            this.PanelTitle.Text = "Add Book";
            this.TitleTextBox.Text = string.Empty;
            this.AuthorTextBox.Text = string.Empty;
            this.ISBNTextBox.Text = string.Empty;
            this.UrlTextBox.Text = string.Empty;
            this.DescrTextBox.Text = string.Empty;
            this.CategoryDropDownList.DataSource = categories;
            this.CategoryDropDownList.DataBind();
            this.EditOrCreateBook.Text = "Add";
            this.EditOrCreateBook.CommandName = "add";
        }

        protected void EditOrCreateBook_Click(object sender, EventArgs e)
        {
             var dbContext = new BooksReviewContext();
           
            Button button = sender as Button;
            if (button.CommandName=="edit")
            {
                int id = Convert.ToInt32(button.CommandArgument);
                var book = dbContext.Books.Find(id);
                book.Title = this.TitleTextBox.Text = book.Title;
                book.Author=this.AuthorTextBox.Text;
                book.ISBN=this.ISBNTextBox.Text;
                book.SiteURL=this.UrlTextBox.Text;
                book.Description=this.DescrTextBox.Text;
                book.CategoryId=Convert.ToInt32(this.CategoryDropDownList.SelectedValue);
            }
            else if (button.CommandName=="delete")
            {
                int id = Convert.ToInt32(button.CommandArgument);
                var book = dbContext.Books.Find(id);
                dbContext.Books.Remove(book);
            }
            else
            {
                var book = new Book ();
                book.Title = this.TitleTextBox.Text;
                book.Author=this.AuthorTextBox.Text;
                book.ISBN=this.ISBNTextBox.Text;
                book.SiteURL=this.UrlTextBox.Text;
                book.Description=this.DescrTextBox.Text;
                book.CategoryId=Convert.ToInt32(this.CategoryDropDownList.SelectedValue);
                dbContext.Books.Add(book);
            }
            dbContext.SaveChanges();
            this.GridViewBooks.DataBind();
            this.BookPanel.Visible = false;
        }

        

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = false;
        }
    }
}