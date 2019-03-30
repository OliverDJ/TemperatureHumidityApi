#!/bin/bash
#start SQL Server, start the script to create the DB and import the data, start the app
/opt/mssql/bin/sqlservr &

MSSQL_PID=$!

# TODO : use environmental variables from mssql.env for '/opt/itera' instead of hardcode
bash /opt/itera/init-db.sh

wait $MSSQL_PID
