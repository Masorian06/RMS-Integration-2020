import numpy as np
import DeepModel_Utilities as uDeep
import matplotlib.pyplot as plt



trainsize = 60000
testsize = 4812

trainset, testset = uDeep.load_dataset(trainsize,testsize)
train_X, train_Y, test_X, test_Y = uDeep.format_Data(trainset, testset)


"""
Set parameters for the Deep Neural Network
"""
layers_dims = [train_X.shape[0], 5, 4, 2, 1]
beta = 0.9
learning_rate = 0.0001
mini_batch_size = 50
num_epochs = 2000
lambd = 0.01
cost_method = "MSLE"
gradient_method = "GD"
"""
"""

parameters_GD, cost_GD = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, optimizer = "gd")
parameters_MTM, cost_MTM = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, optimizer = "momentum")
parameters_ADM, cost_ADM = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, optimizer = "adam")

"""
Make predictions with the parameters learned with each optimazation algorithm
"""
yhat_GD, caches_GD, errs_GD = uDeep.predict(test_X, test_Y, parameters_GD)
yhat_MTM, caches_MTM, errs_MTM = uDeep.predict(test_X, test_Y, parameters_MTM)
yhat_ADM, caches_ADM, errs_ADM = uDeep.predict(test_X, test_Y, parameters_ADM)
"""
-------------------------------------------------------------------------------
"""

"""
Data was normalized in order to input it inside the NN, it needs to be denormalized
"""
maxnum_data = 96.78427641

yhat_GD_dN = yhat_GD[0] * maxnum_data
yhat_MTM_dN = yhat_MTM[0] * maxnum_data
yhat_ADM_dN = yhat_ADM[0] * maxnum_data
test_y_dN = test_Y * maxnum_data
"""
-------------------------------------------------------------------------------
"""

"""
Stack data to make all variables the same size
"""
test_x_Out_Stack = np.sum((test_X * maxnum_data), axis = 0)
"""
-------------------------------------------------------------------------------
"""

"""
Select data for plotting
"""
datasize = 50

plot_yhat_GD = uDeep.selectData(yhat_GD_dN, datasize)
plot_yhat_MTM = uDeep.selectData(yhat_MTM_dN, datasize)
plot_yhat_ADM = uDeep.selectData(yhat_ADM_dN, datasize)
plot_xtest = uDeep.selectData(test_x_Out_Stack, datasize)
plot_trueYtest = uDeep.selectData(test_y_dN, datasize)
samples = list(range(datasize))
"""
"""


#train_X1 = train_X[[0],0:] #* maxnum_data
#train_X1 = np.sum(train_X1, axis = 0)
#train_X2 = train_X[[1],0:] #* maxnum_data
#train_X2 = np.sum(train_X2, axis = 0)
#
#train_X1, train_X2 = np.meshgrid(train_X1.T, train_X2.T)
#cost_GDA = np.array(cost_GD)
#Axes3D.plot_surface(train_X1, train_Y, cost_GDA, rstride = 50)

plt.plot(samples, plot_yhat_GD, c = 'k', label = 'GD')
plt.plot(samples, plot_yhat_ADM, c = 'm', label = 'ADM')
plt.plot(samples, plot_yhat_MTM, c = 'c', label = 'MTM')
plt.plot(samples, plot_xtest, c = 'r', label = 'raw data')
plt.plot(samples, plot_trueYtest, 'r--', c = 'y', label = 'true value')
plt.xlabel('Samples')
plt.ylabel('Acceleration m/s**2')
plt.title('Fitting curves\n' + 'Learning Rate: ' +str(learning_rate))
plt.legend()
plt.figure(figsize=(20,20))
plt.show()

plt.scatter(samples, plot_yhat_GD, c = 'k', label = 'GD')
plt.scatter(samples, plot_yhat_ADM, c = 'm', label = 'ADM')
plt.scatter(samples, plot_yhat_MTM, c = 'c', label = 'MTM')
plt.scatter(samples, plot_xtest, c = 'r', label = 'raw data')
plt.scatter(samples, plot_trueYtest, c = 'y', label = 'true value')
plt.xlabel('Samples')
plt.ylabel('Acceleration m/s**2')
plt.title('Fitting curves\n' + 'Learning Rate: ' + str(learning_rate))
plt.legend()
plt.figure(figsize=(20,20))
plt.show()

plt.plot()
