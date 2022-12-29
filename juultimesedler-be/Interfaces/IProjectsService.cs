﻿using Umbraco.Cms.Core.Models;

namespace juultimesedler_be.Interfaces
{
    public interface IProjectsService
    {
        public IEnumerable<IContent> GetProjects();

        public IEnumerable<IContent> GetCurrentProjects();

        public IList<IContent> GetProjectsByWorkerId(int workerId);
    }
}
