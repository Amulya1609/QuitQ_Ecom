using System;

namespace QuitQ_Ecom.Exceptions
{
    // Custom exception for general errors related to wishlist operations
    public class WishlistException : Exception
    {
        public WishlistException(string message) : base(message)
        {
        }

        public WishlistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom exception for errors related to adding items to the wishlist
    public class AddToWishlistException : WishlistException
    {
        public AddToWishlistException(string message) : base(message)
        {
        }

        public AddToWishlistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

  
    public class GetUserWishlistException : WishlistException
    {
        public GetUserWishlistException(string message) : base(message)
        {
        }

        public GetUserWishlistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom exception for errors related to removing items from the wishlist
    public class RemoveFromWishlistException : WishlistException
    {
        public RemoveFromWishlistException(string message) : base(message)
        {
        }

        public RemoveFromWishlistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

