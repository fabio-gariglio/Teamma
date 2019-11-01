using System;
using System.Net.Http.Headers;
using System.Text;
using Atalassian.Issue;
using Atalassian.Sprint;
using Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrontEnd.Extensions
{
    public static class JiraServiceCollectionExtensions
    {
        public static IServiceCollection AddJiraSupport(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationHeader = GetJiraAuthenticationHeader(configuration);

            services.AddHttpClient("jiraClient", c =>
            {
                c.BaseAddress = new Uri("https://jira.thetrainline.com");
                c.DefaultRequestHeaders.Authorization = authenticationHeader;
            });
            services.AddSingleton<ISprintRepository, SprintRepository>();
            services.AddSingleton<IMapper<JiraSprint, JiraIssueCollection, Sprint>, SprintMapper>();

            return services;
        }

        private static AuthenticationHeaderValue GetJiraAuthenticationHeader(IConfiguration configuration)
        {
            var username = configuration.GetValue<string>("username");
            var password = configuration.GetValue<string>("password");
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

            return new AuthenticationHeaderValue("Basic", credentials);
        }
    }
}
