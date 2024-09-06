#build environment
FROM node:20 as build
WORKDIR /app

#ENV PATH /app/node_modules/.bin:$PATH
COPY package*.json /app/package.json
RUN npm install -g npm@10.5.0 
RUN npm install -g @angular/cli
RUN npm install @angular-devkit/build-angular@latest --save-dev
RUN npm install @angular/core
RUN npm install @angular/router
RUN npm install @angular/platform-browser
RUN npm install @angular/common
RUN npm install @angular/forms
RUN npm install @angular/material
RUN npm install @angular/platform-browser-dynamic
RUN npm install font-awesome --save
# Copie o restante dos arquivos do projeto

#COPY . .
COPY FluxoCaixaFront /app

# Construa o projeto Angular
RUN npm run build

# Etapa de Produção
FROM nginx:alpine

# Copie os arquivos construídos para o diretório padrão do nginx
#COPY --from=build /app/dist/ /usr/share/nginx/html
COPY --from=build /app/dist /usr/share/nginx/html

# Exponha a porta 80
EXPOSE 80

# Inicie o nginx
CMD ["nginx", "-g", "daemon off;"]

