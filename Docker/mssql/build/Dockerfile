FROM microsoft/mssql-server-linux:2017-latest

RUN mkdir -p /opt/itera/

WORKDIR /opt/itera/
COPY . /opt/itera/

CMD ["bash", "/opt/itera/entrypoint.sh"]
