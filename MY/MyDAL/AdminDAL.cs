
using BUDBIZ;
using BUDENTITIES;
using Entities;
using EstablishmentDAL;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {
        #region MONTHS
        public List<Months> GetMonths()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Months> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Months>();
                    while (dr.Read())
                    {
                        Months Temp = new Months();

                        Temp.MonthId = Convert.ToInt32(dr["MONTH_NAMES_ID"]);
                        Temp.MonthName = Convert.ToString(dr["MONTH_NAME"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Employees> GetEmployeeByName(string EmployeeName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_BY_NAME";
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = EmployeeName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Employees> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Employees>();
                    while (dr.Read())
                    {
                        Employees Temp = new Employees();

                        Temp.EmployeeId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.EmployeeName = Convert.ToString(dr["F_NAME"]) + " (" + Convert.ToString(dr["POST"]) + ")";
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.PostId = Convert.ToInt32(dr["POST_HELD"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetItemByName(string Item)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_BY_NAME";
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetItemNameNotAssigned(string Item, int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_NOT_ASSIGNED";
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.VarChar).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"] + " ( " + dr["CURRENT_BALANCE"] + " / " +  dr["THRESHOLD_LEVEL"] + " )");
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetEmpItemNameNotAssigned(string Item, int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_NOT_ASSIGNED";
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.VarChar).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<Items> GetItemsNotInRateList(string Item, int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_NOT_IN_RATE_LIST";
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
                cmd.Parameters.Add("@RateListId", SqlDbType.VarChar).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion
        #region SEARCH
        public List<Items> SearchItems(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<Items> item = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        item = new List<Items>();
                        while (dr.Read())
                        {
                            Items ad = new Items();
                            ad.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                            ad.ItemName = Convert.ToString(dr["ITEM"]);
                            ad.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                            ad.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                            ad.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                            ad.Category = Convert.ToString(dr["CATEGORY"]);
                            ad.CurrentBalance = Convert.ToInt32(dr["CURRENT_BALANCE"]);
                            ad.ThresholdLevel= Convert.ToInt32(dr["THRESHOLD_LEVEL"]);
                            item.Add(ad);
                        }
                    }

                    if (item != null) item.TrimExcess();
                    return item;
                }
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region  VENDORS
        public List<AdminVendor> GetAdminVendor()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDORS";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = 16;
                cmd.CommandType = CommandType.StoredProcedure;
                List<AdminVendor> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<AdminVendor>();
                    while (dr.Read())
                    {
                        AdminVendor Temp = new AdminVendor();
                        Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        Temp.Vendor = Convert.ToString(dr["VENDOR"]);
                        Temp.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        Temp.Contacts = Convert.ToString(dr["CONTACTS"]);
                        Temp.Emails = Convert.ToString(dr["EMAILS"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.NTN = Convert.ToString(dr["NTN"]);
                        Temp.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        Temp.BankName = Convert.ToString(dr["BANK"]);
                        Temp.BankAccount = Convert.ToString(dr["BANK_ACCOUNT"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public AdminVendor GetAdminVendor(int Vendors)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AdminVendor Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new AdminVendor();
                    Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                    Temp.Vendor = Convert.ToString(dr["VENDOR"]);
                    Temp.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                    Temp.Contacts = Convert.ToString(dr["CONTACTS"]);
                    Temp.Emails = Convert.ToString(dr["EMAILS"]);
                    Temp.Details = Convert.ToString(dr["DETAILS"]);
                    Temp.NTN = Convert.ToString(dr["NTN"]);
                    Temp.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                    Temp.BankName = Convert.ToString(dr["BANK"]);
                    Temp.BankAccount = Convert.ToString(dr["BANK_ACCOUNT"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateAdminVendor(AdminVendor Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VENDOR";
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                cmd.Parameters.Add("@Vendor", SqlDbType.VarChar).Value = Temp.Vendor;
                cmd.Parameters.Add("@VenAddress", SqlDbType.VarChar).Value = Temp.Address;
                cmd.Parameters.Add("@Contacts", SqlDbType.VarChar).Value = Temp.Contacts;
                cmd.Parameters.Add("@Emails", SqlDbType.VarChar).Value = Temp.Emails;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@NTN", SqlDbType.VarChar).Value = Temp.NTN;
                cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = Temp.VendorNumber;
                cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = 16;
                cmd.Parameters.Add("@Bank", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@BankAccount", SqlDbType.VarChar).Value = Temp.BankAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertAdminVendor(AdminVendor Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VENDOR";
                cmd.Parameters.Add("@Vendor", SqlDbType.VarChar).Value = Temp.Vendor;
                cmd.Parameters.Add("@VenAddress", SqlDbType.VarChar).Value = Temp.Address;
                cmd.Parameters.Add("@Contacts", SqlDbType.VarChar).Value = Temp.Contacts;
                cmd.Parameters.Add("@Emails", SqlDbType.VarChar).Value = Temp.Emails;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@NTN", SqlDbType.VarChar).Value = Temp.NTN;
                cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = Temp.VendorNumber;
                cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = 16;
                cmd.Parameters.Add("@Bank", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@BankAccount", SqlDbType.VarChar).Value = Temp.BankAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion IT_VENDORS
        #region CATEGORIES
        public List<Categories> GetCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Categories> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Categories>();
                    while (dr.Read())
                    {
                        Categories Temp = new Categories();

                        Temp.CategoryId = Convert.ToInt32(dr["Category_ID"]);
                        Temp.CategoryName = Convert.ToString(dr["Category"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Categories GetCategory(int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_Category";
                cmd.Parameters.Add("@CategoryId", SqlDbType.VarChar).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Categories Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Categories();
                    Temp.CategoryId = Convert.ToInt32(dr["Category_ID"]);
                    Temp.CategoryName = Convert.ToString(dr["Category"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);


                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateCategory(Categories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_Category";
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = Temp.CategoryId;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Temp.CategoryName;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertCategory(Categories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_Category";
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Temp.CategoryName;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion
        #region  MAIN_ITEMS
        public List<MainItems> GetMainItems()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAIN_ITEMS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MainItems> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MainItems>();
                    while (dr.Read())
                    {
                        MainItems Temp = new MainItems();

                        Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                        Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MainItems> GetMainItemsByCat(int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAIN_ITEMS_BY_CAT";
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MainItems> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MainItems>();
                    while (dr.Read())
                    {
                        MainItems Temp = new MainItems();

                        Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                        Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public MainItems GetMainItem(int MainItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAIN_ITEM";
                cmd.Parameters.Add("@MainItemId", SqlDbType.Int).Value = MainItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MainItems Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new MainItems();
                    Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                    Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                    Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                    Temp.Category = Convert.ToString(dr["CATEGORY"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);

                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateMainItem(MainItems Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAIN_ITEM";
                cmd.Parameters.Add("@MainItemId", SqlDbType.Int).Value = Temp.MainItemId;
                cmd.Parameters.Add("@MainItem", SqlDbType.VarChar).Value = Temp.MainItem;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = Temp.CategoryId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertMainItem(MainItems Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MAIN_ITEM";
                cmd.Parameters.Add("@MainItem", SqlDbType.VarChar).Value = Temp.MainItem;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = Temp.CategoryId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MAIN_ITEM
        #region  ITEMS
        public List<Items> GetItems()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEMS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        Temp.Details= Convert.ToString(dr["DETAILS"]);
                        Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                        Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.OpeningBalance= Convert.ToInt32(dr["OPENING_BALANCE"]);
                        Temp.CurrentBalance = Convert.ToInt32(dr["CURRENT_BALANCE"]);
                        Temp.ThresholdLevel = Convert.ToInt32(dr["THRESHOLD_LEVEL"]);
                        Temp.ItemsInPacking = Convert.ToInt32(dr["ITEMS_IN_PACKING"]);
                        Temp.TotalCurrentItems = Convert.ToInt32(dr["TOTAL_CURRENT_ITEMS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetThresholdItems()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEMS_THRESHOLD";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();

                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                        Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.OpeningBalance = Convert.ToInt32(dr["OPENING_BALANCE"]);
                        Temp.CurrentBalance = Convert.ToInt32(dr["CURRENT_BALANCE"]);
                        Temp.ThresholdLevel = Convert.ToInt32(dr["THRESHOLD_LEVEL"]);
                        Temp.ItemsInPacking = Convert.ToInt32(dr["ITEMS_IN_PACKING"]);
                        if(dr["TOTAL_CURRENT_ITEMS"]!=DBNull.Value)
                        Temp.TotalCurrentItems = Convert.ToInt32(dr["TOTAL_CURRENT_ITEMS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetItemsByMainItem(int MainItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEMS_BY_MAIN_ITEM";
                cmd.Parameters.Add("@MainItemId", SqlDbType.Int).Value = MainItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();
                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                        Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.OpeningBalance = Convert.ToInt32(dr["OPENING_BALANCE"]);
                        Temp.CurrentBalance = Convert.ToInt32(dr["CURRENT_BALANCE"]);
                        Temp.ThresholdLevel = Convert.ToInt32(dr["THRESHOLD_LEVEL"]);
                        Temp.ItemsInPacking = Convert.ToInt32(dr["ITEMS_IN_PACKING"]);
                        if (dr["TOTAL_CURRENT_ITEMS"] != DBNull.Value)
                            Temp.TotalCurrentItems = Convert.ToInt32(dr["TOTAL_CURRENT_ITEMS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Items GetItem(int ItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Items Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Items();
                    Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                    Temp.ItemName = Convert.ToString(dr["ITEM"]);
                    Temp.Details = Convert.ToString(dr["DETAILS"]);
                    Temp.MainItemId = Convert.ToInt32(dr["MAIN_ITEM_ID"]);
                    Temp.MainItem = Convert.ToString(dr["MAIN_ITEM"]);
                    Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                    Temp.Category = Convert.ToString(dr["CATEGORY"]);
                    Temp.OpeningBalance = Convert.ToInt32(dr["OPENING_BALANCE"]);
                    Temp.CurrentBalance = Convert.ToInt32(dr["CURRENT_BALANCE"]);
                    Temp.ThresholdLevel= Convert.ToInt32(dr["THRESHOLD_LEVEL"]);
                    Temp.ItemsInPacking = Convert.ToInt32(dr["ITEMS_IN_PACKING"]);
                    if(dr["TOTAL_CURRENT_ITEMS"]!=DBNull.Value)
                    Temp.TotalCurrentItems = Convert.ToInt32(dr["TOTAL_CURRENT_ITEMS"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);

                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
      
        public void UpdateItem(Items Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@MainItemId", SqlDbType.Int).Value = Temp.MainItemId;
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Temp.ItemName;
                cmd.Parameters.Add("@ItemDetails", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@CurrentBalance", SqlDbType.Int).Value = Temp.CurrentBalance;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Temp.Price;
                cmd.Parameters.Add("@PriceUnit", SqlDbType.Int).Value = Temp.PriceUnit;
                cmd.Parameters.Add("@ThresholdLevel", SqlDbType.Int).Value = Temp.ThresholdLevel;
                cmd.Parameters.Add("@ItemsInPacking", SqlDbType.Int).Value = Temp.ItemsInPacking;
                cmd.Parameters.Add("@TotalCurrentItems", SqlDbType.Int).Value = Temp.CurrentBalance * Temp.ItemsInPacking;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertItem(Items Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ITEM";
                cmd.Parameters.Add("@MainItemId", SqlDbType.Int).Value = Temp.MainItemId;
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Temp.ItemName;
                cmd.Parameters.Add("@ItemDetails", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@OpeningBalance", SqlDbType.Int).Value = Temp.OpeningBalance;
                cmd.Parameters.Add("@CurrentBalance", SqlDbType.Int).Value = Temp.CurrentBalance;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Temp.Price;
                cmd.Parameters.Add("@PriceUnit", SqlDbType.Int).Value = Temp.PriceUnit;
                cmd.Parameters.Add("@ThresholdLevel", SqlDbType.Int).Value = Temp.ThresholdLevel;
                cmd.Parameters.Add("@ItemsInPacking", SqlDbType.Int).Value = Temp.ItemsInPacking;
                cmd.Parameters.Add("@TotalCurrentItems", SqlDbType.Int).Value = Temp.CurrentBalance * Temp.ItemsInPacking;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteItem(int ItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion ITEM
        #region  BRANDS
        public List<Brands> GetBrands()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANDS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Brands> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Brands>();
                    while (dr.Read())
                    {
                        Brands Temp = new Brands();

                        Temp.BrandId = Convert.ToInt32(dr["BRAND_ID"]);
                        Temp.Brand = Convert.ToString(dr["BRAND"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Brands GetBrand(int BrandId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANDS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Brands Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Brands();
                    Temp.BrandId = Convert.ToInt32(dr["BRAND_ID"]);
                    Temp.Brand = Convert.ToString(dr["BRAND"]);
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateBrand(Brands Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BRAND";
                cmd.Parameters.Add("@BrandId", SqlDbType.Int).Value = Temp.BrandId;
                cmd.Parameters.Add("@Brand", SqlDbType.VarChar).Value = Temp.Brand;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertBrand(Brands Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BRAND";
                cmd.Parameters.Add("@Brand", SqlDbType.VarChar).Value = Temp.Brand;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion BRANDS
        #region REQUISITIONS
        public List<Requisitions> GetEmployeeRequisitions(int EmployeeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_REQUISITIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = EmployeeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Requisitions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Requisitions>();
                    while (dr.Read())
                    {
                        Requisitions Temp = new Requisitions();

                        Temp.RequisitionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.EmployeeName= Convert.ToString(dr["EMPLOYEE_NAME"]);
                        Temp.PostId = Convert.ToInt32(dr["POST_ID"]);
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.RequisitionDate = Convert.ToDateTime(dr["REQUISITION_DATE"]);
                        Temp.ReqMonth = Convert.ToInt32(dr["REQ_MONTH"]);
                        Temp.ReqYear = Convert.ToInt32(dr["REQ_YEAR"]);
                        Temp.Items = Convert.ToInt32(dr["ITEMS"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Requisitions> GetRequisitionsByStatus(int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REQUISITIONS_BY_STATUS";
                cmd.Parameters.Add("@RequisitionStatusId", SqlDbType.Int).Value = StatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Requisitions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Requisitions>();
                    while (dr.Read())
                    {
                        Requisitions Temp = new Requisitions();

                        Temp.RequisitionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.EmployeeName = Convert.ToString(dr["EMPLOYEE_NAME"]);
                        Temp.PostId = Convert.ToInt32(dr["POST_ID"]);
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.RequisitionDate = Convert.ToDateTime(dr["REQUISITION_DATE"]);
                        Temp.ReqMonth = Convert.ToInt32(dr["REQ_MONTH"]);
                        Temp.ReqYear = Convert.ToInt32(dr["REQ_YEAR"]);
                        Temp.Items = Convert.ToInt32(dr["ITEMS"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Requisitions> GetBranchRequisitions(int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_REQUISITIONS";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Requisitions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Requisitions>();
                    while (dr.Read())
                    {
                        Requisitions Temp = new Requisitions();

                        Temp.RequisitionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch = Convert.ToString(dr["BRANCH"]);
                        Temp.RequisitionDate = Convert.ToDateTime(dr["REQUISITION_DATE"]);
                        Temp.ReqMonth = Convert.ToInt32(dr["REQ_MONTH"]);
                        Temp.ReqYear = Convert.ToInt32(dr["REQ_YEAR"]);
                        Temp.Items = Convert.ToInt32(dr["ITEMS"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Requisitions GetRequisition(int RequisitionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REQUISITION";
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = RequisitionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Requisitions Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Requisitions();
                    Temp.RequisitionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                    Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                    Temp.EmployeeName = Convert.ToString(dr["EMPLOYEE_NAME"]);
                    Temp.RequisitionBy = Convert.ToInt32(dr["REQUISITION_by"]);
                    Temp.PostId = Convert.ToInt32(dr["POST_ID"]);
                    Temp.Post = Convert.ToString(dr["POST"]);
                    Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                    Temp.Branch = Convert.ToString(dr["BRANCH"]);
                    Temp.RequisitionDate = Convert.ToDateTime(dr["REQUISITION_DATE"]);
                    Temp.ReqMonth = Convert.ToInt32(dr["REQ_MONTH"]);
                    Temp.ReqYear = Convert.ToInt32(dr["REQ_YEAR"]);
                    Temp.Items = Convert.ToInt32(dr["ITEMS"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateRequisition(Requisitions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REQUISITION";
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = Temp.RequisitionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Temp.BranchId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = Temp.PostId;
                cmd.Parameters.Add("@RequisitionBy", SqlDbType.Int).Value = Temp.RequisitionBy;
                cmd.Parameters.Add("@RequisitionDate", SqlDbType.Date).Value = Temp.RequisitionDate;
                cmd.Parameters.Add("@ReqMonth", SqlDbType.Int).Value = Temp.RequisitionDate.Month;
                cmd.Parameters.Add("@ReqYear", SqlDbType.Int).Value = Temp.RequisitionDate.Year;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public int InsertRequisition(Requisitions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int Id = new DalHelper().GetPk("ADM_REQUISITIONS", "REQUISITION_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_REQUISITION";
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Temp.BranchId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = Temp.PostId;
                cmd.Parameters.Add("@RequisitionBy", SqlDbType.Int).Value = Temp.RequisitionBy;
                cmd.Parameters.Add("@RequisitionDate", SqlDbType.Date).Value = Temp.RequisitionDate;
                cmd.Parameters.Add("@ReqMonth", SqlDbType.Int).Value = Temp.RequisitionDate.Month;
                cmd.Parameters.Add("@ReqYear", SqlDbType.Int).Value = Temp.RequisitionDate.Year;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return  Id;
             }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteRequisition(int RequisitionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_REQUISITION";
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = RequisitionId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region REQUISITION_ITEM
        public List<RequisitionItems> GetRequistionItems(int RequisitionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REQUISITION_ITEMS";
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = RequisitionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RequisitionItems> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RequisitionItems>();
                    while (dr.Read())
                    {
                        RequisitionItems Temp = new RequisitionItems();
                        Temp.RequisitionItemId = Convert.ToInt32(dr["REQUISITION_ITEM_ID"]);
                        Temp.ItemId= Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.Item = Convert.ToString(dr["ITEM"]);
                        Temp.RequistionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                        Temp.QuantityDemanded = Convert.ToInt32(dr["QUANTITY_DEMAND"]);
                        Temp.QuantityIssued = Convert.ToInt32(dr["QUANTITY_ISSUED"]);
                       
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
       
        public RequisitionItems GetRequisitionItemByItem(int RequisitionId,int ItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REQUISITION_ITEM_BY_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = RequisitionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                RequisitionItems Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new RequisitionItems();
                    Temp.RequisitionItemId = Convert.ToInt32(dr["REQUISITION_ITEM_ID"]);
                    Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                    Temp.Item = Convert.ToString(dr["ITEM"]);
                    Temp.RequistionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                    Temp.QuantityDemanded = Convert.ToInt32(dr["QUANTITY_DEMAND"]);
                    Temp.QuantityIssued = Convert.ToInt32(dr["QUANTITY_ISSUED"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public RequisitionItems GetRequisitionItem(int RequisitionItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REQUISITION_ITEM";
                cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = RequisitionItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                RequisitionItems Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new RequisitionItems();
                    Temp.RequisitionItemId = Convert.ToInt32(dr["REQUISITION_ITEM_ID"]);
                    Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                    Temp.Item = Convert.ToString(dr["ITEM"]);
                    Temp.RequistionId = Convert.ToInt32(dr["REQUISITION_ID"]);
                    Temp.QuantityDemanded = Convert.ToInt32(dr["QUANTITY_DEMAND"]);
                    Temp.QuantityIssued = Convert.ToInt32(dr["QUANTITY_ISSUED"]);


                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        
            public void UpdateQuantityIssued(RequisitionItems Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string log = null;
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REQUISITION_ITEM";
                cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = Temp.RequisitionItemId;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = Temp.RequistionId;
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@QuantityRequested", SqlDbType.Int).Value = Temp.QuantityDemanded;
                cmd.Parameters.Add("@QuantityIssued", SqlDbType.Int).Value = Temp.QuantityIssued;
                RequisitionItems requisitionitem = GetRequisitionItem(Temp.RequisitionItemId);
                log = "<b>Update value in</b> Requisition Id " + requisitionitem.RequistionId + " <br><b>Item</b> " + requisitionitem.Item + ".<br><b>Previous Values:</b> Quantity Requested ( " + requisitionitem.QuantityDemanded + " ) Quantity Issued: ( " + requisitionitem.QuantityIssued + " )";
                log += "<br><b> New Values:</b> Quantity Requested ( " + Temp.QuantityDemanded + " ) Quantity Issued ( " + Temp.QuantityIssued + " ) ";
                AppLog applog = new AppLog();
                applog.Details = log;
                applog.LogTable = "ADM_REQUISITION_ITEMS";
                Items items = GetItem(requisitionitem.ItemId);
                int currentbalance = (items.CurrentBalance + requisitionitem.QuantityIssued) - Temp.QuantityIssued;
                UpdateCurrentBalance(requisitionitem.ItemId, currentbalance);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                InsertLog(applog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateRequisitionItem(RequisitionItems Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string log = null;
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REQUISITION_ITEM";
                cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = Temp.RequisitionItemId;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = Temp.RequistionId;
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@QuantityRequested", SqlDbType.Int).Value = Temp.QuantityDemanded;
                cmd.Parameters.Add("@QuantityIssued", SqlDbType.Int).Value = Temp.QuantityIssued;
                RequisitionItems requisitionitem = GetRequisitionItem(Temp.RequisitionItemId);
                log = "<b>Update value in</b> Requisition Id " + requisitionitem.RequistionId + " <br><b>Item</b> " + requisitionitem.Item + ".<br><b>Previous Values:</b> Quantity Requested ( " + requisitionitem.QuantityDemanded + " ) Quantity Issued: ( " + requisitionitem.QuantityIssued + " )";
                log += "<br><b> New Values:</b> Quantity Requested ( " + Temp.QuantityDemanded + " ) Quantity Issued ( " + Temp.QuantityIssued + " ) ";
                AppLog applog = new AppLog();
                applog.Details = log;
                applog.LogTable = "ADM_REQUISITION_ITEMS";                
                Items items = GetItem(requisitionitem.ItemId);
                int currentbalance = (items.CurrentBalance + requisitionitem.QuantityIssued) - Temp.QuantityIssued;               
                UpdateCurrentBalance(requisitionitem.ItemId, currentbalance);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                InsertLog(applog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertRequisitionItem(RequisitionItems Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int Id = new DalHelper().GetPk("ADM_REQUISITION_ITEMS", "REQUISITION_ITEM_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_REQUISITION_ITEM";
                cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@RequisitionId", SqlDbType.Int).Value = Temp.RequistionId;
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@QuantityRequested", SqlDbType.Int).Value = Temp.QuantityDemanded;
                cmd.Parameters.Add("@QuantityIssued", SqlDbType.Int).Value = Temp.QuantityIssued;
                Items items = GetItem(Temp.ItemId);
                int currentbalance = items.CurrentBalance - Temp.QuantityIssued;
                UpdateCurrentBalance(Temp.ItemId, currentbalance);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteRequisitionItem(int RequisitionItemId) 
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_REQUISITION_ITEM";
                cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = RequisitionItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                RequisitionItems requisitionitem = GetRequisitionItem(RequisitionItemId);
                string log = "<b>Deleted</b> Requisition Id " + requisitionitem.RequistionId + " <br><b>Item</b> " + requisitionitem.Item + ".<br><b>Items:</b> Quantity Requested ( " + requisitionitem.QuantityDemanded + " ) Quantity Issued: ( " + requisitionitem.QuantityIssued + " )";
                AppLog applog = new AppLog();
                applog.Details = log;
                applog.LogTable = "ADM_REQUISITION_ITEMS";
                Items items = GetItem(requisitionitem.ItemId);
                int currentbalance =items.CurrentBalance+requisitionitem.QuantityIssued;
                UpdateCurrentBalance(requisitionitem.ItemId, currentbalance);
                SqlDataReader dr = cmd.ExecuteReader();
                InsertLog(applog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }


        #endregion
        #region BRANCH
        public List<Branch> GetBranches()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_BRANCHES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Branch> branches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branches = new List<Branch>();
                    while (dr.Read())
                    {
                        Branch ad = new Branch();
                        ad.BranchId = Convert.ToInt32(dr["Branches_ID"]);
                        ad.BranchName = Convert.ToString(dr["Description"]);
                        branches.Add(ad);
                    }
                }

                if (branches != null) branches.TrimExcess();
                return branches;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region  PURCHASES
        public List<Purchases> GetPurchases()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PURCHASES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Purchases> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Purchases>();
                    while (dr.Read())
                    {
                        Purchases Temp = new Purchases();
                        Temp.PurchaseId = Convert.ToInt32(dr["PURCHASE_ID"]);
                        Temp.InvoiceNumber = Convert.ToString(dr["INVOICE_NUMBER"]);
                        Temp.InvoiceDate = Convert.ToDateTime(dr["INVOICE_DATE"]);
                        Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        Temp.VendorName = Convert.ToString(dr["VENDOR_NAME"]);
                        Temp.OfficeFileNo = Convert.ToString(dr["OFFICE_FILE_NO"]);
                        Temp.OfficeFileDate = Convert.ToDateTime(dr["OFFICE_FILE_DATE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Purchases GetPurchase(int PurchaseId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PURCHASE";
                cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = PurchaseId;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Purchases Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Purchases();
                    Temp.PurchaseId = Convert.ToInt32(dr["PURCHASE_ID"]);
                    Temp.InvoiceNumber = Convert.ToString(dr["INVOICE_NUMBER"]);
                    Temp.InvoiceDate = Convert.ToDateTime(dr["INVOICE_DATE"]);
                    Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                    Temp.VendorName = Convert.ToString(dr["VENDOR_NAME"]);
                    Temp.OfficeFileNo = Convert.ToString(dr["OFFICE_FILE_NO"]);
                    Temp.OfficeFileDate = Convert.ToDateTime(dr["OFFICE_FILE_DATE"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdatePurchases(Purchases Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PURCHASE";
                cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = Temp.PurchaseId;
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Temp.InvoiceNumber;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = Temp.InvoiceDate;
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                cmd.Parameters.Add("@OfficeFileNo", SqlDbType.VarChar).Value = Temp.OfficeFileNo;
                cmd.Parameters.Add("@OfficeFileDate", SqlDbType.DateTime).Value = Temp.OfficeFileDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertPurchases(Purchases Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PURCHASE";
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Temp.InvoiceNumber;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = Temp.InvoiceDate;
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                cmd.Parameters.Add("@OfficeFileNo", SqlDbType.VarChar).Value = Temp.OfficeFileNo;
                cmd.Parameters.Add("@OfficeFileDate", SqlDbType.DateTime).Value = Temp.OfficeFileDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion PURCHASES
        #region  UNITS
        public List<CalcUnit> GetUnits()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNITS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<CalcUnit> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CalcUnit>();
                    while (dr.Read())
                    {
                        CalcUnit Temp = new CalcUnit();

                        Temp.UnitId = Convert.ToInt32(dr["UNIT_ID"]);
                        Temp.Description = Convert.ToString(dr["UNIT"]);
                        Temp.NumberOfItems = Convert.ToInt32(dr["NO_OF_ITEMS"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public CalcUnit GetUnit(int UnitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNIT";
                cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = UnitId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                CalcUnit Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new CalcUnit();
                    Temp.UnitId = Convert.ToInt32(dr["UNIT_ID"]);
                    Temp.Description = Convert.ToString(dr["UNIT"]);
                    Temp.NumberOfItems = Convert.ToInt32(dr["NO_OF_ITEMS"]);



                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateUnit(CalcUnit Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_UNIT";
                cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = Temp.UnitId;
                cmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@NoOfItems", SqlDbType.Int).Value = Temp.NumberOfItems;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertUnit(CalcUnit Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_UNIT";
                cmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@NoOfItems", SqlDbType.Int).Value = Temp.NumberOfItems;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion UNIT
        #region RATE_LIST
        public List<RateList> GetRateListByVendor(int VendorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_RATE_LISTS";
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = VendorId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RateList> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RateList>();
                    while (dr.Read())
                    {
                        RateList Temp = new RateList();
                        Temp.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                        Temp.RateListDes = Convert.ToString(dr["RATE_LIST_NAME"]);
                        Temp.RateListDate = Convert.ToDateTime(dr["RATE_LIST_DATE"]);
                        Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        Temp.VendorName = Convert.ToString(dr["VENDOR"]);
                        Temp.IsActive= Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public RateList GetRateList(int RateListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RATE_LIST";
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                RateList Temp = null;
                if (dr.HasRows)
                {
                        dr.Read();
                        Temp = new RateList();
                        Temp.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                        Temp.RateListDes = Convert.ToString(dr["RATE_LIST_NAME"]);
                        Temp.RateListDate = Convert.ToDateTime(dr["RATE_LIST_DATE"]);
                        Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        Temp.VendorName = Convert.ToString(dr["VENDOR"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);

                }

               
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateRateList(RateList Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RATE_LIST";
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = Temp.RateListId;
                cmd.Parameters.Add("@RateListName", SqlDbType.Int).Value = Temp.RateListDes;
                //cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                //cmd.Parameters.Add("@RateListDate", SqlDbType.Date).Value = Temp.RateListDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertRateList(RateList Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RATE_LIST";
                cmd.Parameters.Add("@RateListName", SqlDbType.VarChar).Value = Temp.RateListDes;
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                cmd.Parameters.Add("@RateListDate", SqlDbType.Date).Value = Temp.RateListDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateCurrentBalance(int ItemId,int CurrentBalance)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ITEM_CURRENT_BALANCE";
                cmd.Parameters.Add("@ItemId", SqlDbType.VarChar).Value = ItemId;
                cmd.Parameters.Add("@CurrentBalance", SqlDbType.Int).Value = CurrentBalance;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        //public void DeleteRequisitionItem(int RequisitionItemId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_REQUISITION_ITEM";
        //        cmd.Parameters.Add("@RequisitionItemId", SqlDbType.Int).Value = RequisitionItemId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}


        #endregion
        #region RATE_LIST_ITEMS
        public List<RateListItem> GetRateListItems(int RateListID)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RATE_LIST_ITEMS";
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListID;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RateListItem> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RateListItem>();
                    while (dr.Read())
                    {
                        RateListItem Temp = new RateListItem();
                        Temp.RateListItemId = Convert.ToInt32(dr["RATE_LIST_ITEM_ID"]);
                        Temp.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        Temp.Price = Convert.ToInt32(dr["PRICE"]);
                        Temp.UnitId = Convert.ToInt32(dr["PRICE_UNIT"]);
                        Temp.Unit= Convert.ToString(dr["UNIT"]);
                        Temp.UnitItems= Convert.ToInt32(dr["NO_OF_ITEMS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public RateListItem GetRateListItem(int RateListId,int ItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]",con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RATE_LIST_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                RateListItem Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new RateListItem();
                    Temp.RateListItemId = Convert.ToInt32(dr["RATE_LIST_ITEM_ID"]);
                    Temp.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                    Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                    Temp.ItemName = Convert.ToString(dr["ITEM"]);
                    Temp.Price = Convert.ToInt32(dr["PRICE"]);
                    Temp.UnitId = Convert.ToInt32(dr["PRICE_UNIT"]);
                    Temp.Unit = Convert.ToString(dr["UNIT"]);
                    Temp.UnitItems = Convert.ToInt32(dr["NO_OF_ITEMS"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateRateListItem(RateListItem Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RATE_LIST_ITEM";
                 cmd.Parameters.Add("@RateListItemId", SqlDbType.Int).Value = Temp.RateListItemId;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Temp.Price;
                cmd.Parameters.Add("@PriceUnit", SqlDbType.Int).Value = Temp.UnitId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertRateListItem(RateListItem Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RATE_LIST_ITEM";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Temp.Price;
                cmd.Parameters.Add("@PriceUnit", SqlDbType.Int).Value = Temp.UnitId;
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = Temp.RateListId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
       
        public void DeleteRateListItem(int RateListItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_RATE_LIST_ITEM";
                cmd.Parameters.Add("@RateListItemId", SqlDbType.Int).Value = RateListItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion
        #region PURCHASE_ITEMS
        public List<PurchaseItem> GetPurchaseItems(int PurchaseID)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PURCHASE_ITEMS";
                cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = PurchaseID;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PurchaseItem> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<PurchaseItem>();
                    while (dr.Read())
                    {

                        PurchaseItem Temp = new PurchaseItem();
                        Temp.PurchaseItemId = Convert.ToInt32(dr["PURCHASE_ITEM_ID"]);
                        Temp.PurchaseId = Convert.ToInt32(dr["PURCHASE_ID"]);
                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.Item = Convert.ToString(dr["ITEM"]);
                        Temp.SingleItemPrice= Convert.ToInt32(dr["SINGLE_UNIT_PRICE"]);
                        Temp.Quantity= Convert.ToInt32(dr["QUANTITY"]);
                        Temp.UnitId = Convert.ToInt32(dr["UNIT_ID"]);
                        Temp.Unit = Convert.ToString(dr["UNIT"]);
                        Temp.UnitQuantity = Convert.ToInt32(dr["NO_OF_ITEMS"]);
                        Temp.TotalItems = Temp.Quantity * Temp.UnitQuantity;
                        Temp.TotalPrice = Temp.SingleItemPrice * Temp.Quantity;
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public PurchaseItem GetPurchaseItem(int PurchaseItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PURCHASE_ITEM";
                cmd.Parameters.Add("@PurchaseItemId", SqlDbType.Int).Value = PurchaseItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                PurchaseItem Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new PurchaseItem();
                    Temp.PurchaseItemId = Convert.ToInt32(dr["PURCHASE_ITEM_ID"]);
                    Temp.PurchaseId = Convert.ToInt32(dr["PURCHASE_ID"]);
                    Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                    Temp.Item = Convert.ToString(dr["ITEM"]);
                    Temp.SingleItemPrice = Convert.ToInt32(dr["SINGLE_UNIT_PRICE"]);
                    Temp.Quantity = Convert.ToInt32(dr["QUANTITY"]);
                    Temp.UnitId = Convert.ToInt32(dr["UNIT_ID"]);
                    Temp.Unit = Convert.ToString(dr["UNIT"]);
                    Temp.UnitQuantity = Convert.ToInt32(dr["NO_OF_ITEMS"]);
                    Temp.TotalItems = Temp.Quantity * Temp.UnitQuantity;
                    Temp.TotalPrice = Temp.SingleItemPrice / Temp.Quantity;
                    Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdatePurchaseItem(PurchaseItem Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PURCHASE_ITEM";
                cmd.Parameters.Add("@PurchaseItemId", SqlDbType.Int).Value = Temp.PurchaseItemId;
                cmd.Parameters.Add("@SingleUnitPrice", SqlDbType.Int).Value = Temp.SingleItemPrice;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Temp.Quantity;
                cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = Temp.UnitId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                CalcUnit unit = GetUnit(Temp.UnitId);
                int quantity = Temp.Quantity * unit.NumberOfItems;               
                cmd.CommandType = CommandType.StoredProcedure;
                UpdatePurchasedInventory(Temp.PurchaseItemId, quantity);
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertPurchaseItem(PurchaseItem Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PURCHASE_ITEM";
                cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = Temp.PurchaseId;
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = Temp.ItemId;
                cmd.Parameters.Add("@SingleUnitPrice", SqlDbType.Int).Value = Temp.SingleItemPrice;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Temp.Quantity;
                cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = Temp.UnitId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                CalcUnit Unit = GetUnit(Temp.UnitId);
                Items items = GetItem(Temp.ItemId);
                int currentbalance = items.CurrentBalance + (Temp.Quantity * Unit.NumberOfItems) ;
                UpdateCurrentBalance(Temp.ItemId, currentbalance);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Items> GetItemsNotInPurchase(string Item, int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_NOT_IN_PURCHASE";
                cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
                cmd.Parameters.Add("@PurchaseId", SqlDbType.VarChar).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Items> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Items>();
                    while (dr.Read())
                    {
                        Items Temp = new Items();
                        Temp.ItemId = Convert.ToInt32(dr["ITEM_ID"]);
                        Temp.ItemName = Convert.ToString(dr["ITEM"]);
                        Rate rate = GetItemRate(Temp.ItemId,Id);
                        if (rate != null)
                        {
                            Temp.PriceUnit = rate.UnitId;
                            Temp.Price = rate.Price;
                        }                                  
                        MyList.Add(Temp);
                    }
                }
                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        protected Rate GetItemRate(int itemid,int Id)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                Bills bill = new BudgetBiz().GetBill(Id);
                int vendorid = bill.VendorId;
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ITEM_RATE";
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemid;
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = vendorid;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Rate rate = new Rate();
                if (dr.HasRows)
                {
                    dr.Read();
                    rate.UnitId = Convert.ToInt32(dr["PRICE_UNIT"]);
                    rate.Price = Convert.ToInt32(dr["PRICE"]);
                }
                return rate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeletePurchaseItem(int PurchaseItemId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_PURCHASE_ITEM";
                cmd.Parameters.Add("@PurchaseItemId", SqlDbType.Int).Value = PurchaseItemId;
                cmd.CommandType = CommandType.StoredProcedure;
                PurchaseItem purchaseitem = GetPurchaseItem(PurchaseItemId);
                Items item = GetItem(purchaseitem.ItemId);
                int currentbalance=(item.CurrentBalance-purchaseitem.TotalItems);
                UpdateCurrentBalance(purchaseitem.ItemId, currentbalance);
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region UPDATE_INVENTORY
        protected void UpdatePurchasedInventory(int PurchaseItemId, int Quantity)
        {
            PurchaseItem purchaseitem = GetPurchaseItem(PurchaseItemId);
            Items item = GetItem(purchaseitem.ItemId);
            item.CurrentBalance = item.CurrentBalance - purchaseitem.TotalItems;
            item.CurrentBalance += Quantity;
            UpdateCurrentBalance(purchaseitem.ItemId, item.CurrentBalance);
        }
        #endregion
        #region LOG
        public void InsertLog(AppLog Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_LOG";
                cmd.Parameters.Add("@LogDetails", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@LogDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@LogTable", SqlDbType.VarChar).Value = Temp.LogTable;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public List<AppLog> GetLog()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Admin_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOG";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<AppLog> logs = new List<AppLog>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        AppLog log = new AppLog();
                        log.LogId = Convert.ToInt32(dr["LOG_ID"]);
                        log.Details = Convert.ToString(dr["DETAILS"]);
                        log.LogDate = Convert.ToDateTime(dr["LOG_DATE"]);
                        log.LogTable = Convert.ToString(dr["LOG_TABLE"]);
                        logs.Add(log);
                    }

                }
                if (logs != null) logs.TrimExcess();
                return logs;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
    }

    
}
