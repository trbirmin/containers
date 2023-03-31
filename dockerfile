FROM php:7.4-apache

ENV TRUDIS_VALUE "This is my secret - sha256:fb5a4c8af82f00730b7427e47bda7f76cea2e2b9aea421750bc9025"

COPY . /var/www/html