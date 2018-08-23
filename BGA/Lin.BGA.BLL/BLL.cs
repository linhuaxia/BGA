 
using Lin.BGA.IBLL;
using Lin.BGA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.BLL
{
	
	public partial class AppVersionInfoService :BaseService<AppVersionInfo>,IAppVersionInfoService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.AppVersionInfoDAL;
        }
    }   
	
	public partial class CategoryInfoService :BaseService<CategoryInfo>,ICategoryInfoService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.CategoryInfoDAL;
        }
    }   
	
	public partial class MusicInfoService :BaseService<MusicInfo>,IMusicInfoService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.MusicInfoDAL;
        }
    }   
	
	public partial class ProfilesInfoService :BaseService<ProfilesInfo>,IProfilesInfoService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.ProfilesInfoDAL;
        }
    }   
	
	public partial class StoreInfoService :BaseService<StoreInfo>,IStoreInfoService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.StoreInfoDAL;
        }
    }   
	
	public partial class sysdiagramsService :BaseService<sysdiagrams>,IsysdiagramsService
    {
    

		 public override void SetCurrentDAL()
        {
            CurrentDAL = this.CurrentDBSession.sysdiagramsDAL;
        }
    }   
	
}