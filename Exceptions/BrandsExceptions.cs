using System;

namespace QuitQ_Ecom.Exceptions
{
    public class BrandRepositoryException : Exception
    {
        public BrandRepositoryException()
        {
        }

        public BrandRepositoryException(string message) : base(message)
        {
        }

        public BrandRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class BrandNotFoundException : BrandRepositoryException
    {
        public BrandNotFoundException(string message) : base(message)
        {
        }

        public BrandNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class AddBrandException : BrandRepositoryException
    {
        public AddBrandException(string message) : base(message)
        {
        }

        public AddBrandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DeleteBrandException : BrandRepositoryException
    {
        public DeleteBrandException(string message) : base(message)
        {
        }

        public DeleteBrandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetAllBrandsException : BrandRepositoryException
    {
        public GetAllBrandsException(string message) : base(message)
        {
        }

        public GetAllBrandsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetBrandByIdException : BrandRepositoryException
    {
        public GetBrandByIdException(string message) : base(message)
        {
        }

        public GetBrandByIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class UpdateBrandException : BrandRepositoryException
    {
        public UpdateBrandException(string message) : base(message)
        {
        }

        public UpdateBrandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
