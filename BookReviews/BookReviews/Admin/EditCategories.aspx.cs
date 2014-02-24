using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviews.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddCategory.Visible = true;
            
        }

       
        public IQueryable<Category> GridViewCategories_GetData()
        {
            IQueryable<Category> cateories = null;
            var dbContext = new BooksReviewContext();
            cateories = dbContext.Categories.AsQueryable<Category>();
            return cateories;
        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            this.AddCategory.Visible = false;
            this.PanelTitle.Text = "Add Category";
            this.EditOrCreateCategotyPanel.Visible = true;
            this.EditOrCreateCategotyTextBox.Text = string.Empty;
            this.EditOrCreateCategotyButton.Text = "Add";
            this.EditOrCreateCategotyButton.CommandName = "add";
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            this.PanelTitle.Text = "Edit Category";
            this.AddCategory.Visible = false;
            this.EditOrCreateCategotyPanel.Visible = true;
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            using (var dbContext = new BooksReviewContext())
            {
                var category=dbContext.Categories.Find(id);
                this.EditOrCreateCategotyTextBox.Text = category.Name;
                this.EditOrCreateCategotyButton.Text = "Edit";
                this.EditOrCreateCategotyButton.CommandArgument = id.ToString();
                this.EditOrCreateCategotyButton.CommandName = "edit";
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            this.AddCategory.Visible = false;
            this.PanelTitle.Text = "Confirm Delete Category";
            this.EditOrCreateCategotyPanel.Visible = true;
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            using (var dbContext = new BooksReviewContext())
            {

                var category = dbContext.Categories.Find(id);
                this.EditOrCreateCategotyTextBox.Text = category.Name;
                this.EditOrCreateCategotyTextBox.ReadOnly = true;
                this.EditOrCreateCategotyButton.Text = "Delete";
                this.EditOrCreateCategotyButton.CommandArgument = id.ToString();
                this.EditOrCreateCategotyButton.CommandName = "delete";
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
           
            this.EditOrCreateCategotyPanel.Visible = false;
        }

        protected void EditOrCreateCategotyButton_Click(object sender, EventArgs e)
        {
            var dbContext = new BooksReviewContext();
            string categoryName = this.EditOrCreateCategotyTextBox.Text;
            Button button = sender as Button;
            if (button.CommandName=="edit")
            {
                int id = Convert.ToInt32(button.CommandArgument);
                var category = dbContext.Categories.Find(id);
                category.Name = categoryName;
            }
            else if (button.CommandName=="delete")
            {
                int id = Convert.ToInt32(button.CommandArgument);
                var category = dbContext.Categories.Find(id);
                var books = category.Books.ToList();
                dbContext.Books.RemoveRange(books);
                dbContext.Categories.Remove(category);
            }
            else
            {
                var category = new Category { Name = categoryName };
                dbContext.Categories.Add(category);
            }

            try
            {
              
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
               
                this.ErrorLabel.Text = ex.Message;
            }
            this.GridViewCategories.DataBind();
            this.EditOrCreateCategotyPanel.Visible = false;
        }

       
    }
}