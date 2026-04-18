using MVCForumApp.Models;

namespace MVCForumApp.Tests
{
    public class TopicTest
    {
        [Fact]
        public void Topic_ShouldBeMade_and_ShouldShowResponses()
        {

            var topic = new Topic { Title = "Test topic 1", Description = "This is a test :D", Posts = new List<Post>() };
            var post = new Post { Content = "Test post" };
            topic.Posts.Add(post);

            Assert.Single(topic.Posts);
            Assert.Equal("Test post", topic.Posts.First().Content);
        }

        [Fact]
        public void NewTopic_ShouldHaveZeroResponses_AtStart()
        {

            var topic = new Topic { Title = "Test topic 2", Description = "This is a test :D", Posts = new List<Post>() };

            Assert.Equal(0, topic.RepliesCount);
        }

        [Fact]
        public void Topic_IncrementReplies_ShouldIncreaseCount()
        {
            var topic = new Topic { Title = "Test topic 3", RepliesCount = 0 };
            topic.IncrementReplies();
            Assert.Equal(1, topic.RepliesCount);
        }

        [Fact]
        public void Topic_IncrementReplies_ShouldIncreaseCount_v2()
        {
            var topic = new Topic { Title = "Test topic 3", RepliesCount = 0, Posts = new List<Post>() };

            var post = new Post { Content = "Test post" };
            topic.Posts.Add(post);
            topic.IncrementReplies();

            Assert.Equal(1, topic.RepliesCount);
        }
    }
}