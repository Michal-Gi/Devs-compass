﻿using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Services
{
    public class UserService(ApiDbContext context)
    {
        public async Task<ActionResult<Developer>> GetDeveloperAsync(int id)
        {
            var developer = await context.Developers.FindAsync(id);
            return developer;
        }

        public async Task<ActionResult<Organizer>> GetOrganizerAsync(int id)
        {
            var organizer = await context.Organizers.FindAsync(id);
            return organizer;
        }

        public async Task<ActionResult<UserVM>> AddDeveloperAsync(CreateUserRequest request)
        {
            var developer = new Developer
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password
            };

            await context.Developers.AddAsync(developer);
            await context.SaveChangesAsync();
            return new UserVM
            {
                Id = developer.Id,
                Login = developer.Login,
                Password = developer.Password,
                Email = developer.Email,
            };
        }

        public async Task<ActionResult<UserVM>> AddOrganizerAsync(CreateUserRequest request)
        {
            var organizer = new Organizer
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password
            };

            await context.AddAsync(organizer);
            await context.SaveChangesAsync();

            return new UserVM
            {
                Email = organizer.Email,
                Login = organizer.Login,
                Password = organizer.Password,
                Id = organizer.Id
            };
        }
    }
}