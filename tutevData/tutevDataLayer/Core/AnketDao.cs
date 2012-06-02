using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class AnketDao:BaseDbDao {

		private Anket nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public AnketDao() {}

		public int Insert(Anket nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO ANKET (ORGANIZASYON_ID,ACIKLAMA)VALUES(@organizasyonId,@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Anket nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE ANKET set ORGANIZASYON_ID = @organizasyonId , ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ANKET where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Anket nesne = new Anket();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Anket GetById(int id,Database db){
 			nesne = new Anket();
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillAnket(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Anket> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Anket> anketList = new List<Anket>();
				while(reader.Read()){
					Anket anket = FillAnket(reader);
					anketList.Add( anket);
				}
				return anketList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 OrganizasyonId,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET Where 1=1 
 						 and (ORGANIZASYON_ID = @organizasyonId or @organizasyonId =-1)
						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, OrganizasyonId);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public Anket FillAnket(IDataReader reader){
 			nesne = new Anket();
			nesne.Id=(Int32)reader["ID"];
			nesne.OrganizasyonId=(Int32)reader["ORGANIZASYON_ID"];
			nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}

		public DataSet GetByOrganizasyonId(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByOrganizasyonIdReader(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteReader(dbComm);
		}

		public List<Anket> GetByOrganizasyonIdList (string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_ID,ACIKLAMA from ANKET Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Anket> anketList = new List<Anket>();
				while(reader.Read()){
					Anket anket = FillAnket(reader);
					anketList.Add( anket);
				}
				return anketList;
			}
		}

		public int DeleteByOrganizasyonId(Int32 organizasyonId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ANKET where ORGANIZASYON_ID=@organizasyonId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			Anket nesne=new Anket();
			nesne.Id=-1;
			nesne.OrganizasyonId=organizasyonId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
