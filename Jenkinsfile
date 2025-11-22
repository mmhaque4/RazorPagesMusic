pipeline {
    agent any

    environment {
        APP_REPO = 'https://github.com/mmhaque4/RazorPagesMusic.git'
        APP_DIR = 'RazorPagesMusic'
        ANSIBLE_REPO = 'https://github.com/mmhaque4/ansible_playbooks.git'
        ANSIBLE_DIR = 'ansible_playbooks'
        VENV_DIR = '/var/lib/jenkins/.venvs/ansible-venv'
        PYTHON = "${VENV_DIR}/bin/python3"
        ANSIBLE_PLAYBOOK = "${VENV_DIR}/bin/ansible-playbook"
    }

    stages {
        stage('Clean Workspace') {
            steps {
                echo "🧹 Cleaning workspace (excluding venv)..."
                sh """
                    rm -rf ${APP_DIR} ${ANSIBLE_DIR}
                """
            }
        }

        stage('Checkout Application Branch') {
            steps {
                echo "📦 Checking out the current branch from SCM..."
                checkout scm
            }
        }

        stage('Clone Ansible Repo') {
            steps {
                echo "📦 Cloning ansible_playbooks repository..."
                dir("${ANSIBLE_DIR}") {
                    git branch: 'main',
                        url: "${ANSIBLE_REPO}",
                        credentialsId: 'Github-credens'
                }
            }
        }

        stage('Setup Python Virtual Environment') {
            steps {
                script {
                    if (!fileExists("${VENV_DIR}/bin/ansible-playbook")) {
                        echo "🐍 Creating Python virtual environment and installing Ansible..."
                        sh """
                            mkdir -p /var/lib/jenkins/.venvs
                            python3 -m venv "${VENV_DIR}"
                            ${VENV_DIR}/bin/pip install --upgrade pip
                            ${VENV_DIR}/bin/pip install ansible pywinrm
                        """
                    } else {
                        echo "✅ Virtual environment already exists. Skipping installation."
                    }
                }
            }
        }

        stage('Run Ansible Playbook') {
            steps {
                dir("${ANSIBLE_DIR}") {
                    echo "🚀 Running Ansible playbook..."
                    sh """
                        ${ANSIBLE_PLAYBOOK} windows-deploy.yml -i inventory.ini -e app_source_dir=${WORKSPACE}
                    """
                }
            }
        }
    }

    post {
        success {
            echo '✅ Deployment completed successfully!'
        }
        failure {
            echo '❌ Deployment failed. Check Jenkins console output for details.'
        }
    }
}
