FROM node:19-alpine

# Set the working directory
WORKDIR /app

# Install pnpm
RUN npm install -g pnpm

# Copy package.json and pnpm-lock.yaml
COPY package.json pnpm-lock.yaml ./

# Install dependencies
RUN pnpm install

# Copy the rest of the files
COPY . .

# # Build the app
# RUN pnpm run build

# Start the app
# CMD ["pnpm", "run", "serve"]
CMD ["pnpm", "dev"]