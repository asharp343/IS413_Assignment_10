using System;
namespace IS413_Assignment_10.Models.ViewModels
{
    public class PageNumberInfo
    {

        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calculate num pages
        public int NumPages => (int)Math.Ceiling(((decimal)TotalNumItems / NumItemsPerPage));
    }
}
