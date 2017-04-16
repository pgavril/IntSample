using System;
using System.Collections.Generic;
using System.Linq;
using InterviewSample.Data;

namespace InterviewSample.Data
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
