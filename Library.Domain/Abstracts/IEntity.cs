﻿namespace Library.Domain.Abstracts;

public interface IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
