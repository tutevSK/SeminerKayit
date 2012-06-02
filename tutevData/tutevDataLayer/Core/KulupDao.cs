using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class KulupDao:BaseDbDao {

		private Kulup nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public KulupDao() {}

		public int Insert(Kulup nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO KULUP (ID,AD,SIFRE)VALUES(@id,@ad,@sifre)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@sifre", DbType.String, nesne.Sifre==null?(object)DBNull.Value:nesne.Sifre);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Kulup nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE KULUP set AD = @ad , SIFRE = @sifre WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@sifre", DbType.String, nesne.Sifre==null?(object)DBNull.Value:nesne.Sifre);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KULUP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Kulup nesne = new Kulup();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Kulup GetById(int id,Database db){
 			nesne = new Kulup();
			sqlText="Select ID,AD,SIFRE from KULUP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillKulup(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SIFRE from KULUP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SIFRE from KULUP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Kulup> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,AD,SIFRE from KULUP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Kulup> kulupList = new List<Kulup>();
				while(reader.Read()){
					Kulup kulup = FillKulup(reader);
					kulupList.Add( kulup);
				}
				return kulupList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Ad,String Sifre,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,AD,SIFRE from KULUP Where 1=1 
 						 and (AD like @ad or @ad ='')
						 and (SIFRE like @sifre or @sifre ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@ad", DbType.String, Ad);
			db.AddInParameter(dbComm, "@sifre", DbType.String, Sifre);
			return db.ExecuteDataSet(dbComm);
		}


		public Kulup FillKulup(IDataReader reader){
 			nesne = new Kulup();
			nesne.Id=(Int32)reader["ID"];
			if(!(reader["AD"] is System.DBNull))nesne.Ad=(String)reader["AD"];
			if(!(reader["SIFRE"] is System.DBNull))nesne.Sifre=(String)reader["SIFRE"];
			return nesne;
		}
	}
}
