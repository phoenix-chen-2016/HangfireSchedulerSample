#! /bin/bash

envsubst '${API_PROTO} ${API_HOST} ${API_PORT} ${FORWARDED_PORT}' < /etc/nginx/conf.d/default.conf.template > /etc/nginx/conf.d/default.conf

if [ $# = 0 ]
then
    exec nginx -g 'daemon off;'
else
    exec "$@"
fi
