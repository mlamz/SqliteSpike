
    drop table if exists Tag

    drop table if exists ProductTag

    drop table if exists Release

    drop table if exists Product

    create table Tag (
        TagId UNIQUEIDENTIFIER not null,
       Name TEXT,
       primary key (TagId)
    )

    create table ProductTag (
        TagId UNIQUEIDENTIFIER not null,
       ProductId UNIQUEIDENTIFIER not null
    )

    create table Release (
        ReleaseId UNIQUEIDENTIFIER not null,
       Title TEXT,
       ProductId UNIQUEIDENTIFIER,
       primary key (ReleaseId)
    )

    create table Product (
        ProductId UNIQUEIDENTIFIER not null,
       Title TEXT,
       primary key (ProductId)
    )
