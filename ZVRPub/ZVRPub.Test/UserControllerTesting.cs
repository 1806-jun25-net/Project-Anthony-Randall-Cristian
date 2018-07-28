using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZVRPub.MVCFrontEnd.Controllers;
using ZVRPub.MVCFrontEnd.Models;

namespace ZVRPub.Test
{
    public class UserControllerTesting
    {
        public HttpClient HttpClient { get; }

        [Fact]
        public async Task UserControllerIndexAsyncShouldReturnTheProperView()
        {
            var controller = new UserController(HttpClient);
            var result = await controller.IndexAsync("name") as ViewResult;

            Assert.Equal("IndexAsync", result.ViewName);
        }
    }
}
