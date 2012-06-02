using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class KatilimciDao:BaseDbDao {

		private Katilimci nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public KatilimciDao() {}

		public int Insert(Katilimci nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO KATILIMCI (AD,SOYAD,TELEFON,EMAIL,UNVAN_ID)VALUES(@ad,@soyad,@telefon,@email,@unvanId)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@soyad", DbType.String, nesne.Soyad==null?(object)DBNull.Value:nesne.Soyad);
			db.AddInParameter(dbComm, "@telefon", DbType.String, nesne.Telefon==null?(object)DBNull.Value:nesne.Telefon);
			db.AddInParameter(dbComm, "@email", DbType.String, nesne.Email==null?(object)DBNull.Value:nesne.Email);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, nesne.UnvanId==null?(object)DBNull.Value:nesne.UnvanId);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Katilimci nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE KATILIMCI set AD = @ad , SOYAD = @soyad , TELEFON = @telefon , EMAIL = @email , UNVAN_ID = @unvanId WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@soyad", DbType.String, nesne.Soyad==null?(object)DBNull.Value:nesne.Soyad);
			db.AddInParameter(dbComm, "@telefon", DbType.String, nesne.Telefon==null?(object)DBNull.Value:nesne.Telefon);
			db.AddInParameter(dbComm, "@email", DbType.String, nesne.Email==null?(object)DBNull.Value:nesne.Email);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, nesne.UnvanId==null?(object)DBNull.Value:nesne.UnvanId);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Katilimci nesne = new Katilimci();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Katilimci GetById(int id,Database db){
 			nesne = new Katilimci();
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillKatilimci(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Katilimci> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Katilimci> katilimciList = new List<Katilimci>();
				while(reader.Read()){
					Katilimci katilimci = FillKatilimci(reader);
					katilimciList.Add( katilimci);
				}
				return katilimciList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Ad,String Soyad,String Telefon,String Email,Int32 UnvanId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI Where 1=1 
 						 and (AD like @ad or @ad ='')
						 and (SOYAD like @soyad or @soyad ='')
						 and (TELEFON like @telefon or @telefon ='')
						 and (EMAIL like @email or @email ='')
						 and (UNVAN_ID = @unvanId or @unvanId =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@ad", DbType.String, Ad);
			db.AddInParameter(dbComm, "@soyad", DbType.String, Soyad);
			db.AddInParameter(dbComm, "@telefon", DbType.String, Telefon);
			db.AddInParameter(dbComm, "@email", DbType.String, Email);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, UnvanId);
			return db.ExecuteDataSet(dbComm);
		}


		public Katilimci FillKatilimci(IDataReader reader){
 			nesne = new Katilimci();
			nesne.Id=(Int32)reader["ID"];
			nesne.Ad=(String)reader["AD"];
			nesne.Soyad=(String)reader["SOYAD"];
			nesne.Telefon=(String)reader["TELEFON"];
			nesne.Email=(String)reader["EMAIL"];
			nesne.UnvanId=(Int32)reader["UNVAN_ID"];
			return nesne;
		}

		public DataSet GetByUnvanId(string OrderBy,Int32 unvanId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI Where UNVAN_ID=@unvanId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, unvanId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByUnvanIdReader(string OrderBy,Int32 unvanId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI Where UNVAN_ID=@unvanId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, unvanId);
			return db.ExecuteReader(dbComm);
		}

		public List<Katilimci> GetByUnvanIdList (string OrderBy,Int32 unvanId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SOYAD,TELEFON,EMAIL,UNVAN_ID from KATILIMCI Where UNVAN_ID=@unvanId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, unvanId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Katilimci> katilimciList = new List<Katilimci>();
				while(reader.Read()){
					Katilimci katilimci = FillKatilimci(reader);
					katilimciList.Add( katilimci);
				}
				return katilimciList;
			}
		}

		public int DeleteByUnvanId(Int32 unvanId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI where UNVAN_ID=@unvanId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@unvanId", DbType.Int32, unvanId);
			Katilimci nesne=new Katilimci();
			nesne.Id=-1;
			nesne.UnvanId=unvanId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
