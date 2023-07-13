namespace Achuu.Models
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public string? Hex_value { get; set; }
        public string? Colour_name { get; set; }
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


