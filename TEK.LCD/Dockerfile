FROM node:18

# Set the environment variable for OpenSSL legacy provider
ENV NODE_OPTIONS=--openssl-legacy-provider

# Install necessary packages for building images
RUN apt-get update && apt-get install -y \
    gcc \
    make \
    build-essential \
    libpng-dev \
    pngquant \
    gifsicle \
    libjpeg-progs \
    && rm -rf /var/lib/apt/lists/*

# Create and change to the app directory
WORKDIR /app

# Copy application dependency manifests to the container image
COPY TEK.LCD/package*.json ./

# Copy the npmcheckversion.js script
COPY TEK.LCD/internals/scripts/npmcheckversion.js ./internals/scripts/npmcheckversion.js

# Copy the entire webpack folder
COPY TEK.LCD/internals/webpack ./internals/webpack

RUN npm install -g pngquant-bin

# Install production dependencies with --legacy-peer-deps
RUN npm install --only=production --legacy-peer-deps

# Install development dependencies for build
RUN npm install --only=dev --legacy-peer-deps

# Copy the local code to the container image
COPY TEK.LCD/. .

# Copy the .env file
COPY .env .env

# Run prebuild
RUN npm run prebuild

# Build the application
# RUN npx webpack --config internals/webpack/webpack.prod.babel.js --color -p --progress --hide-modules --display-optimization-bailout

# Define build arguments
ARG CLIENT_KEY
ARG CLIENT_LOCATION
ARG SETTING_TIMER
ARG ROOM_TIMER
ARG TNB_TIMER
ARG CLS_TIMER
ARG CLS_ROW
ARG APP_LOGO
ARG APP_FOOTER_SLOGAN
ARG END_POINT
ARG END_POINT_DEPT
ARG API_AUDIO_RING
ARG URL_VIDEO
ARG API_TEMP_URL
ARG SUB_URL_API_TEMP
ARG API_TEMP_KEY
ARG LOCATION
ARG NODE_ENV
ARG CFG_ENV

# Convert build arguments to environment variables
ENV CLIENT_KEY=${CLIENT_KEY}
ENV CLIENT_LOCATION=${CLIENT_LOCATION}
ENV SETTING_TIMER=${SETTING_TIMER}
ENV ROOM_TIMER=${ROOM_TIMER}
ENV TNB_TIMER=${TNB_TIMER}
ENV CLS_TIMER=${CLS_TIMER}
ENV CLS_ROW=${CLS_ROW}
ENV APP_LOGO=${APP_LOGO}
ENV APP_FOOTER_SLOGAN=${APP_FOOTER_SLOGAN}
ENV END_POINT=${END_POINT}
ENV END_POINT_DEPT=${END_POINT_DEPT}
ENV API_AUDIO_RING=${API_AUDIO_RING}
ENV URL_VIDEO=${URL_VIDEO}
ENV API_TEMP_URL=${API_TEMP_URL}
ENV SUB_URL_API_TEMP=${SUB_URL_API_TEMP}
ENV API_TEMP_KEY=${API_TEMP_KEY}
ENV LOCATION=${LOCATION}
ENV NODE_ENV=${NODE_ENV}
ENV CFG_ENV=${CFG_ENV}

# Expose the port the app runs on
EXPOSE 3000

# Run the web service on container startup
CMD [ "npm", "start" ]
