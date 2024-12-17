pipeline {
    agent any

    stages {
        stage('Hello') {
            steps {
                echo 'Hello jenkins'
            }
        }
		stage('Start Docker Container') {
            steps {
                sh 'docker compose up -d'
            }
        }
    }
}
