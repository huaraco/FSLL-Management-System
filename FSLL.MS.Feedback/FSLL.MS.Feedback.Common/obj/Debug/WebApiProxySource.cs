

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;


	// Proxies
namespace FSLLProxies.Core
{
    public partial class Configuration
	{
		public const string FSLLCoreApiProxyBaseAddress = "http://fsll.dyndns.org/fsll_ms_core/";
		
	}
}

namespace FSLLProxies.Core.Models
{
	#region Models
	public partial class LoginModel
	{
		public virtual String MembershipNo { get; set; }
		public virtual String Password { get; set; }
		public virtual Boolean IsRemeberMe { get; set; }
	}
	#endregion
	#region Models
	public partial class AuthorizedModel
	{
		public virtual String Roles { get; set; }
		public virtual Int32 MemberID { get; set; }
		public virtual Nullable<Int32> GroupID { get; set; }
	}
	#endregion
	#region Models
	public partial class MemberModel
	{
		public virtual Int32 MemberID { get; set; }
		public virtual String MemberName { get; set; }
		public virtual String Email { get; set; }
		public virtual String EnglishName { get; set; }
		public virtual String AbstractName { get; set; }
		public virtual GroupModel DefaultGroup { get; set; }
		public virtual IList<GroupModel> Groups { get; set; }
	}
	#endregion
	#region Models
	public partial class GroupModel
	{
		public virtual Int32 GroupID { get; set; }
		public virtual String GroupName { get; set; }
		public virtual Int32 GroupTypeID { get; set; }
		public virtual String GroupTypeName { get; set; }
		public virtual Int32 ParentGroupID { get; set; }
		public virtual String ParentGroupName { get; set; }
	}
	#endregion
}


namespace FSLLProxies.Core.Clients
{
	using FSLLProxies.Core.Models;
	public partial class AccountClient : IDisposable
	{

		public HttpClient HttpClient { get; private set; }

		/// <summary>
        /// Account Controller
        /// </summary>
		public AccountClient()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.FSLLCoreApiProxyBaseAddress)
			};
		}

		/// <summary>
        /// Account Controller
        /// </summary>
		public AccountClient(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.FSLLCoreApiProxyBaseAddress)
			};
		}

		#region Methods
        /// <summary>
        /// Test
        /// </summary>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> TestAsync()
		{
			return await HttpClient.GetAsync("api/Account/Test");
		}

		/// <summary>
        /// Test
        /// </summary>
			
        /// <returns></returns>
		public virtual HttpResponseMessage Test()
		{
			return HttpClient.GetAsync("api/Account/Test").Result;
		}

        /// <summary>
        /// Login
        /// </summary>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> LoginAsync(LoginModel model)
		{
			return await HttpClient.PostAsJsonAsync<LoginModel>("api/Account/Login", model);
		}

		/// <summary>
        /// Login
        /// </summary>
			
        /// <returns></returns>
		public virtual HttpResponseMessage Login(LoginModel model)
		{
			return HttpClient.PostAsJsonAsync<LoginModel>("api/Account/Login", model).Result;
		}

        /// <summary>
        /// 
        /// </summary>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> IsAuthorizedAsync(AuthorizedModel model)
		{
			return await HttpClient.PostAsJsonAsync<AuthorizedModel>("api/Account/IsAuthorized", model);
		}

		/// <summary>
        /// 
        /// </summary>
			
        /// <returns></returns>
		public virtual HttpResponseMessage IsAuthorized(AuthorizedModel model)
		{
			return HttpClient.PostAsJsonAsync<AuthorizedModel>("api/Account/IsAuthorized", model).Result;
		}

        /// <summary>
        /// List all church members
        /// </summary>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> ListAllMembersAsync()
		{
			return await HttpClient.GetAsync("api/Account/ListAllMembers");
		}

		/// <summary>
        /// List all church members
        /// </summary>
			
        /// <returns></returns>
		public virtual HttpResponseMessage ListAllMembers()
		{
			return HttpClient.GetAsync("api/Account/ListAllMembers").Result;
		}

        /// <summary>
        /// List all the members of a certain group
        /// </summary>
				/// <param name="groupid"></param>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> ListMemberOfGroupAsync(Int32 groupid)
		{
			return await HttpClient.GetAsync("api/Account/ListMemberOfGroup?groupid=" + groupid);
		}

		/// <summary>
        /// List all the members of a certain group
        /// </summary>
				/// <param name="groupid"></param>
			
        /// <returns></returns>
		public virtual HttpResponseMessage ListMemberOfGroup(Int32 groupid)
		{
			return HttpClient.GetAsync("api/Account/ListMemberOfGroup?groupid=" + groupid).Result;
		}

        /// <summary>
        /// List all the groups of a member
        /// </summary>
				/// <param name="memberId"></param>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> ListMemberGroupsAsync(Int32 memberId)
		{
			return await HttpClient.GetAsync("api/Account/ListMemberGroups?memberId=" + memberId);
		}

		/// <summary>
        /// List all the groups of a member
        /// </summary>
				/// <param name="memberId"></param>
			
        /// <returns></returns>
		public virtual HttpResponseMessage ListMemberGroups(Int32 memberId)
		{
			return HttpClient.GetAsync("api/Account/ListMemberGroups?memberId=" + memberId).Result;
		}

        /// <summary>
        /// Check whether members are from same cell group
        /// </summary>
				/// <param name="memberId1"></param>
				/// <param name="memberId2"></param>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> IsInSameGroupAsync(Int32 memberId1,Int32 memberId2)
		{
			return await HttpClient.GetAsync("api/Account/IsInSameGroup?memberId1=" + memberId1 + "&memberId2=" + memberId2);
		}

		/// <summary>
        /// Check whether members are from same cell group
        /// </summary>
				/// <param name="memberId1"></param>
				/// <param name="memberId2"></param>
			
        /// <returns></returns>
		public virtual HttpResponseMessage IsInSameGroup(Int32 memberId1,Int32 memberId2)
		{
			return HttpClient.GetAsync("api/Account/IsInSameGroup?memberId1=" + memberId1 + "&memberId2=" + memberId2).Result;
		}

        /// <summary>
        /// 
        /// </summary>
				/// <param name="memberId"></param>
		        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetMemberAsync(Int32 memberId)
		{
			return await HttpClient.GetAsync("api/Account/GetMember?memberId=" + memberId);
		}

		/// <summary>
        /// 
        /// </summary>
				/// <param name="memberId"></param>
			
        /// <returns></returns>
		public virtual HttpResponseMessage GetMember(Int32 memberId)
		{
			return HttpClient.GetAsync("api/Account/GetMember?memberId=" + memberId).Result;
		}

		#endregion

		public void Dispose()
        {
            HttpClient.Dispose();
        }
	}

}



