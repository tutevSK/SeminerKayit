using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class SoruDao:BaseDbDao {

		private Soru nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public SoruDao() {}

		public int Insert(Soru nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO SORU (SORU_METNI,SECENEK_TIP)VALUES(@soruMetni,@secenekTip)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruMetni", DbType.String, nesne.SoruMetni==null?(object)DBNull.Value:nesne.SoruMetni);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, nesne.SecenekTip==null?(object)DBNull.Value:nesne.SecenekTip);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Soru nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE SORU set SORU_METNI = @soruMetni , SECENEK_TIP = @secenekTip WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@soruMetni", DbType.String, nesne.SoruMetni==null?(object)DBNull.Value:nesne.SoruMetni);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, nesne.SecenekTip==null?(object)DBNull.Value:nesne.SecenekTip);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SORU where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Soru nesne = new Soru();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Soru GetById(int id,Database db){
 			nesne = new Soru();
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillSoru(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Soru> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Soru> soruList = new List<Soru>();
				while(reader.Read()){
					Soru soru = FillSoru(reader);
					soruList.Add( soru);
				}
				return soruList;
			}
		}

		public DataSet GetByAll(string OrderBy,String SoruMetni,Int32 SecenekTip,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,SORU_METNI,SECENEK_TIP from SORU Where 1=1 
 						 and (SORU_METNI like @soruMetni or @soruMetni ='')
						 and (SECENEK_TIP = @secenekTip or @secenekTip =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruMetni", DbType.String, SoruMetni);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, SecenekTip);
			return db.ExecuteDataSet(dbComm);
		}


		public Soru FillSoru(IDataReader reader){
 			nesne = new Soru();
			nesne.Id=(Int32)reader["ID"];
			nesne.SoruMetni=(String)reader["SORU_METNI"];
			nesne.SecenekTip=(Int32)reader["SECENEK_TIP"];
			return nesne;
		}

		public DataSet GetBySecenekTip(string OrderBy,Int32 secenekTip,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU Where SECENEK_TIP=@secenekTip "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, secenekTip);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySecenekTipReader(string OrderBy,Int32 secenekTip,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU Where SECENEK_TIP=@secenekTip "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, secenekTip);
			return db.ExecuteReader(dbComm);
		}

		public List<Soru> GetBySecenekTipList (string OrderBy,Int32 secenekTip,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,SORU_METNI,SECENEK_TIP from SORU Where SECENEK_TIP=@secenekTip "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, secenekTip);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Soru> soruList = new List<Soru>();
				while(reader.Read()){
					Soru soru = FillSoru(reader);
					soruList.Add( soru);
				}
				return soruList;
			}
		}

		public int DeleteBySecenekTip(Int32 secenekTip,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SORU where SECENEK_TIP=@secenekTip ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekTip", DbType.Int32, secenekTip);
			Soru nesne=new Soru();
			nesne.Id=-1;
			nesne.SecenekTip=secenekTip;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
