
using System;
namespace QuitQ_Ecom.Exceptions


{
    public class CartRepositoryException : Exception
    {
        public CartRepositoryException(string message) : base(message)
        {
        }

        public CartRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetUserCartItemsException : CartRepositoryException
    {
        public GetUserCartItemsException(string message) : base(message)
        {
        }

        public GetUserCartItemsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class AddNewProductToCartException : CartRepositoryException
    {
        public AddNewProductToCartException(string message) : base(message)
        {
        }

        public AddNewProductToCartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class IncreaseProductQuantityException : CartRepositoryException
    {
        public IncreaseProductQuantityException(string message) : base(message)
        {
        }

        public IncreaseProductQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DecreaseProductQuantityException : CartRepositoryException
    {
        public DecreaseProductQuantityException(string message) : base(message)
        {
        }

        public DecreaseProductQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class RemoveProductFromCartException : CartRepositoryException
    {
        public RemoveProductFromCartException(string message) : base(message)
        {
        }

        public RemoveProductFromCartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetTotalCartCostException : CartRepositoryException
    {
        public GetTotalCartCostException(string message) : base(message)
        {
        }

        public GetTotalCartCostException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class RemoveCartItemsOfUserException : CartRepositoryException
    {
        public RemoveCartItemsOfUserException(string message) : base(message)
        {
        }

        public RemoveCartItemsOfUserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidCartItemException : CartRepositoryException
    {
        public InvalidCartItemException(string message) : base(message)
        {
        }

        public InvalidCartItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class ProductNotFoundException : CartRepositoryException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class CartNotFoundException : CartRepositoryException
    {
        public CartNotFoundException(string message) : base(message)
        {
        }

        public CartNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InsufficientStockException : CartRepositoryException
    {
        public InsufficientStockException(string message) : base(message)
        {
        }

        public InsufficientStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class CartEmptyException : CartRepositoryException
    {
        public CartEmptyException(string message) : base(message)
        {
        }

        public CartEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

