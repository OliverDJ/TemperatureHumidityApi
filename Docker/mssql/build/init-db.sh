#!/bin/bash

#wait for the SQL Server to come up
sleep 30s

echo "I am started using user $MASTER_USER and password $SA_PASSWORD, with DB_NAME=$DB_NAME"

#run the setup script to create the DB and the schema in the DB
# -U == username
# -P == password
# -i == init script for SQL databases etc...
# TODO : use environmental variables from mssql.env for '/opt/itera' instead of hardcode
/opt/mssql-tools/bin/sqlcmd -S localhost -U $MASTER_USER -P $SA_PASSWORD -d master -i /opt/itera/init.sql 
