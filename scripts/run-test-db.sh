#!/bin/bash

docker run -it --rm --link expense-reports-dev-db:postgres postgres psql -h postgres -U postgres