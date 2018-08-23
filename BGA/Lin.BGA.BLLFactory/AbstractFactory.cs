 

using Lin.BGA.IBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.BLLFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IAppVersionInfoService CreateAppVersionInfoService()
        {

			string fullClassName = AssemblyNameSpace + ".AppVersionInfoService";
			return CreateInstance(fullClassName) as IAppVersionInfoService;

        }
		
	    public static ICategoryInfoService CreateCategoryInfoService()
        {

			string fullClassName = AssemblyNameSpace + ".CategoryInfoService";
			return CreateInstance(fullClassName) as ICategoryInfoService;

        }
		
	    public static IMusicInfoService CreateMusicInfoService()
        {

			string fullClassName = AssemblyNameSpace + ".MusicInfoService";
			return CreateInstance(fullClassName) as IMusicInfoService;

        }
		
	    public static IProfilesInfoService CreateProfilesInfoService()
        {

			string fullClassName = AssemblyNameSpace + ".ProfilesInfoService";
			return CreateInstance(fullClassName) as IProfilesInfoService;

        }
		
	    public static IStoreInfoService CreateStoreInfoService()
        {

			string fullClassName = AssemblyNameSpace + ".StoreInfoService";
			return CreateInstance(fullClassName) as IStoreInfoService;

        }
		
	    public static IsysdiagramsService CreatesysdiagramsService()
        {

			string fullClassName = AssemblyNameSpace + ".sysdiagramsService";
			return CreateInstance(fullClassName) as IsysdiagramsService;

        }
	}
	
}