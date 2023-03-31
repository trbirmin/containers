FROM httpd:bullseye
#RUN apt install python3
COPY . /usr/local/apache2/htdocs/
#ENTRYPOINT [ "http" ]