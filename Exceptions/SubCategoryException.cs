using System;

namespace QuitQ_Ecom.Repository
{
    // Custom exception for when a subcategory is not found
    public class SubCategoryNotFoundException : Exception
    {
        public SubCategoryNotFoundException(string message) : base(message) { }
    } 
}
