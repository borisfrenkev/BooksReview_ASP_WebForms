using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookReviews.Models;
using System.Web.ModelBinding;

namespace BookReviews
{
    public partial class BooksList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
          
        }

       
        public IQueryable<Category> BookListGetData()
        {
            var dbContext = new BooksReviewContext();
            IQueryable<Category> categories = null;
            categories = dbContext.Categories.AsQueryable<Category>();
          
            return categories;
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchString = Request.Form["SearchText"];
             if (!string.IsNullOrEmpty(searchString))
             {
                 Response.Redirect("~/Search.aspx?str="+searchString);
             }
        
        }
    }
}