CREATE TYPE currency AS ENUM ('yen', 'eur', 'dollar');

CREATE TABLE users (
    id integer PRIMARY KEY,
    first_name varchar(128),
    last_name varchar(128),
    middle_name varchar(128)
);

CREATE TABLE receipts (
    id integer PRIMARY KEY,
    user_id integer REFERENCES users (id),
    currency currency,
    amount money
);