using mg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTS
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            var task = new mg.Task("Test task");
            _taskManager.AddTask(task);
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            var task = new mg.Task("chwilowy task");
            _taskManager.AddTask(task);
            _taskManager.RemoveTask(0);
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
            foreach ( var t in _taskManager.GetTasks() )
            {
                if (t.Title != "chwilowy task")
                {
                    Assert.AreEqual(1, 2);
                }
            }
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            var task = new mg.Task("nie wykonany task");
            _taskManager.AddTask(task);
            _taskManager.MarkTaskAsCompleted(1);
            Assert.AreEqual(true, _taskManager.GetTaskById(1).IsCompleted);
        }

    }
}
