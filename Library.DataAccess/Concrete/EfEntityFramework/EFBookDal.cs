﻿using Library.DataAccess.Abstract;
using Library.DataAccess.context;
using Library.Domain.Entities;
using Library.Repository.DataAccess.EFDataAccess;

namespace Library.DataAccess.Concrete.EfEntityFramework;

public class EFBookDal : EFEntityRepositoryBase<Book, LibraryDbContext>, IBookDal
{

}