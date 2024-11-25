using System;

namespace QuitQ_Ecom.Exceptions
{
    public class CategoryRepositoryException : Exception
    {
        public CategoryRepositoryException()
        {
        }

        public CategoryRepositoryException(string message) : base(message)
        {
        }

        public CategoryRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class CategoryNotFoundException : CategoryRepositoryException
    {
        public CategoryNotFoundException(string message) : base(message)
        {
        }

        public CategoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class AddCategoryException : CategoryRepositoryException
    {
        public AddCategoryException(string message) : base(message)
        {
        }

        public AddCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DeleteCategoryException : CategoryRepositoryException
    {
        public DeleteCategoryException(string message) : base(message)
        {
        }

        public DeleteCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetAllCategoriesException : CategoryRepositoryException
    {
        public GetAllCategoriesException(string message) : base(message)
        {
        }

        public GetAllCategoriesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetCategoryByIdException : CategoryRepositoryException
    {
        public GetCategoryByIdException(string message) : base(message)
        {
        }

        public GetCategoryByIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetProductsByCategoryException : CategoryRepositoryException
    {
        public GetProductsByCategoryException(string message) : base(message)
        {
        }

        public GetProductsByCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetSubcategoriesByCategoryException : CategoryRepositoryException
    {
        public GetSubcategoriesByCategoryException(string message) : base(message)
        {
        }

        public GetSubcategoriesByCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class UpdateCategoryException : CategoryRepositoryException
    {
        public UpdateCategoryException(string message) : base(message)
        {
        }

        public UpdateCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidCategoryOperationException : CategoryRepositoryException
    {
        public InvalidCategoryOperationException(string message) : base(message)
        {
        }

        public InvalidCategoryOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class SubcategoryNotFoundException : CategoryRepositoryException
    {
        public SubcategoryNotFoundException(string message) : base(message)
        {
        }

        public SubcategoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    

    // Add more custom exceptions as needed
}
