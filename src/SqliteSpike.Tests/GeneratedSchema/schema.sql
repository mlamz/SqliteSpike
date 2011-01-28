
    drop table if exists Tag

    drop table if exists ProductTag

    drop table if exists Release

    drop table if exists Product

    create table Tag (
        Id UNIQUEIDENTIFIER not null,
       Name TEXT,
       primary key (Id)
    )

    create table ProductTag (
        TagId UNIQUEIDENTIFIER not null,
       ProductId UNIQUEIDENTIFIER not null
    )

    create table Release (
        Id UNIQUEIDENTIFIER not null,
       Title TEXT,
       primary key (Id)
    )

    create table Product (
        Id UNIQUEIDENTIFIER not null,
       Title TEXT,
       primary key (Id)
    )
