FROM node:19-alpine AS build

# Set variables(arguments)
ARG API_URL
ARG FRONTEND_PORT

# Set the environment variables
ENV VITE_API_URL=$API_URL
ENV VITE_FRONTEND_PORT=$FRONTEND_PORT

# Set the working directory
WORKDIR /app

# Copy package.json and pnpm-lock.yaml
COPY package.json pnpm-lock.yaml ./

# Install dependencies

RUN npm install -g pnpm \
    && pnpm install

# Copy the rest of the files
COPY . .

# Build the app
RUN pnpm build

# Add reverse proxy
FROM nginx:1.21-alpine

COPY --from=build /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf