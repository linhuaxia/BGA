 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.IDAL
{
	public partial interface IDBSession
    {
	
		IAppVersionInfoDAL AppVersionInfoDAL{get;set;}
	
		ICategoryInfoDAL CategoryInfoDAL{get;set;}
	
		IMusicInfoDAL MusicInfoDAL{get;set;}
	
		IProfilesInfoDAL ProfilesInfoDAL{get;set;}
	
		IStoreInfoDAL StoreInfoDAL{get;set;}
	
		IsysdiagramsDAL sysdiagramsDAL{get;set;}
	}	
}