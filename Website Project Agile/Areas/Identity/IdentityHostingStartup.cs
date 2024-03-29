﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website_Project_Agile.Areas.Identity.Data;
using Website_Project_Agile.Data;

[assembly: HostingStartup(typeof(Website_Project_Agile.Areas.Identity.IdentityHostingStartup))]
namespace Website_Project_Agile.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}