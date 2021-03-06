﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> review)
        {

            var recordedData = (from productReviews in review
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void SelectedRecords(List<ProductReview> review)
        {
            var recordedData = from productReviews in review
                               where (productReviews.ProductID == 1 && productReviews.Rating > 3) || (productReviews.ProductID == 4 && productReviews.Rating > 3) ||
                               (productReviews.ProductID == 9 && productReviews.Rating > 3)
                               select productReviews;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void RetrieveCountOfRecords(List<ProductReview> review)
        {
            var recordedData = review.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-----" + list.Count);
            }
        }
        public void RetrieveProductIdAndReview(List<ProductReview> review)
        {
            var recordedData = from productReviews in review
                               select new { productReviews.ProductID, productReviews.Review };
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "Review:-" + list.Review);
            }
        }
        public void SkipTopRecords(List<ProductReview> review)
        {
            var recordedData = (from productReviews in review
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void ProductReviewsDataTable(List<ProductReview> review)
        {
            var recordedData = from productReviews in review
                               select productReviews;
            dataTable.Columns.Add("ProductId").DataType = typeof(Int32);
            dataTable.Columns.Add("UserId").DataType = typeof(Int32);
            dataTable.Columns.Add("Rating").DataType = typeof(double);
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike").DataType = typeof(bool);
            foreach (var list in recordedData)
            {
                dataTable.Rows.Add(list.ProductID, list.UserID, list.Rating, list.Review, list.isLike);
            }
            var productTable = from products in dataTable.AsEnumerable() select products;
            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("productId") + " " + product.Field<int>("UserId") + " "
                    + product.Field<double>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
        public void RetriveRecordsFromDataTable()
        {
            var productTable = from products in this.dataTable.AsEnumerable() where products.Field<bool>("isLike").Equals(true) select products;
            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("productId") + " " + product.Field<int>("UserId") + " "
                    + product.Field<double>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
        public void AveragePerProductId(List<ProductReview> review)
        {
            var recordedData = review.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, AverageRating = x.Average(x => x.Rating) });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-----" + list.AverageRating);
            }
        }
        public void RetrieveRecordsUsingReview(List<ProductReview> review, string reviewPoint)
        {
            var recordedData = from productReviews in review
                               where productReviews.Review == reviewPoint
                               select productReviews;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void RetriveRecordsFromDataTableUsingUserID()
        {
            var productTable = from products in this.dataTable.AsEnumerable() where products.Field<int>("UserId") == 10 select products;
            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("productId") + " " + product.Field<int>("UserId") + " "
                    + product.Field<double>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
    }
}
