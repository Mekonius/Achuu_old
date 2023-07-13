using System.ComponentModel.DataAnnotations.Schema;

namespace Achuu.Models
{
    public class Product
    {
        //Creating a product
        //public int ProductID { get; set; }
        //public string? Name { get; set; }
        //public string? GalleryID { get; set; }
        //public string? Description { get; set; }
        //public string? Warning { get; set; }
     

        public int? ProductID { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image_link { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public object? Rating { get; set; }
        public string? Category { get; set; }
        public string? ProductType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ProductApiUrl { get; set; }
        public string? ApiFeatured_image { get; set; }
        public List<ProductColor>? ProductColors { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

    }


}

//CREATE TABLE [dbo].[Products] (

//    [ProductID][int] IDENTITY(1, 1) NOT NULL,

//    [Name] [nvarchar] (max)NULL,
//	[GalleryID][nvarchar] (max)NULL,
//	[Description][nvarchar] (max)NULL,
//	[Warning][nvarchar] (max)NULL,
//	[LockerID][int] NULL,
// CONSTRAINT[PK_Products] PRIMARY KEY CLUSTERED 
//(

//    [ProductID] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
//GO

//ALTER TABLE [dbo].[Products] WITH CHECK ADD  CONSTRAINT [FK_Products_Lockers_LockerID] FOREIGN KEY([LockerID])
//REFERENCES[dbo].[Lockers]([LockerID])
//GO

//ALTER TABLE [dbo].[Products] CHECK CONSTRAINT[FK_Products_Lockers_LockerID]
//GO


