pipeline {
    agent any
    environment {
        dotnet = '/usr/share/dotnet/sdk'
    }
    stages {
        stage('Checkout Stage') {
            steps {
                git url: 'https://github.com/aditya050102/ProductAPI.git', branch: 'main'
            }
        }
        stage('Build Stage') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Test Stage') {
            steps {
                sh 'dotnet test ${WORKSPACE}/TestProject1/TestProject1.csproj'
            }
        }
    }
    post {
        success {
            echo 'Build and test successful!'
        }
    }
}