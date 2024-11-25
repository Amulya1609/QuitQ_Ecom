using System;

namespace QuitQ_Ecom.Repository.Exceptions
{
    public class AddProductException : Exception
    {
        public AddProductException(string message) : base(message) { }
    }

    public class GetProductsBySubCategoryException : Exception
    {
        public GetProductsBySubCategoryException(string message) : base(message) { }
    }

    public class GetProductByIdException : Exception
    {
        public GetProductByIdException(string message) : base(message) { }
    }

    public class UpdateProductException : Exception
    {
        public UpdateProductException(string message) : base(message) { }
    }

    public class DeleteProductByIDException : Exception
    {
        public DeleteProductByIDException(string message) : base(message) { }
    }

    public class CheckQuantityOfProductsException : Exception
    {
        public CheckQuantityOfProductsException(string message) : base(message) { }
    }

    public class UpdateQuantitiesOfProductsException : Exception
    {
        public UpdateQuantitiesOfProductsException(string message) : base(message) { }
    }

    public class SearchProductsException : Exception
    {
        public SearchProductsException(string message) : base(message) { }
    }

    public class GetAllProductsException : Exception
    {
        public GetAllProductsException(string message) : base(message) { }
    }

    public class GetAllProductsByStoreIdException : Exception
    {
        public GetAllProductsByStoreIdException(string message) : base(message) { }
    }

    public class FilterProductsException : Exception
    {
        public FilterProductsException(string message) : base(message) { }
    }
    public class UpdateProductQuantityException : Exception
    {
        public UpdateProductQuantityException() { }
        public UpdateProductQuantityException(string message) : base(message) { }
        public UpdateProductQuantityException(string message, Exception inner) : base(message, inner) { }
    }

    public class SearchProductException : Exception
    {
        public SearchProductException() { }
        public SearchProductException(string message) : base(message) { }
        public SearchProductException(string message, Exception inner) : base(message, inner) { }
    }

    public class DeleteProductException : Exception
    {
        public DeleteProductException() { }
        public DeleteProductException(string message) : base(message) { }
        public DeleteProductException(string message, Exception inner) : base(message, inner) { }
    }

    public class CheckProductQuantityException : Exception
    {
        public CheckProductQuantityException() { }
        public CheckProductQuantityException(string message) : base(message) { }
        public CheckProductQuantityException(string message, Exception inner) : base(message, inner) { }
    }
}

