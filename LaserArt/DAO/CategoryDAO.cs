﻿using LaserArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaserArt.DAO
{
    public class CategoryDAO:DAO
    {
        public static List<Category> getProducts(int? id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Category> newCategoryList = new List<Category>();
                        while (rdr.Read())
                        {
                            Category newCategory = new Category();
                            newCategory.Id = Convert.ToInt32(rdr["Id"]);
                            newCategory.CategoryName = rdr["CategoryName"].ToString();

                            newCategoryList.Add(newCategory);
                        }
                        return newCategoryList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }
    }
}