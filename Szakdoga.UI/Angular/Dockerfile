FROM node:latest-alpine as build-step
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . /app
RUN ng build --watch
EXPOSE 4201:80
