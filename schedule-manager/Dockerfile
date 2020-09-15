FROM nginx AS base
EXPOSE 80

FROM node AS sdk
WORKDIR /src
COPY . .
RUN npm i
RUN npx ng build --prod

FROM base AS final
ENV API_PROTO=http
ENV API_HOST=localhost
ENV API_PORT=80
ENV FORWARDED_PORT=80
COPY nginx/default.conf.template /etc/nginx/conf.d/
COPY nginx/entry.bash /
COPY --from=sdk /src/dist/schedule-manager /usr/share/nginx/html
ENTRYPOINT [ "/entry.bash" ]
