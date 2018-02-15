﻿using LinqToDB.Mapping;

class Customer
{
    [PrimaryKey]
    [NotNull]
    public string Id { get; set; }

    public string CompanyName { get; set; }

    public string ContactName { get; set; }

    public string ContactTitle { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}